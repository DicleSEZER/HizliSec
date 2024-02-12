using HizliSec.Business.Abstract;
using HizliSec.Entities.Concrete.Dtos.UserDtos;
using HizliSec.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System.Transactions;
using Microsoft.EntityFrameworkCore;

namespace HizliSec.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUnitOfWork _unitOfWork;

        public AuthManager(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<IdentityResult> AddToRoleAsync(AppUser appUser, string role)
        {

            AppRole appRole = _roleManager.Roles.FirstOrDefault(x => x.Name == role);
            if (appRole is null)
            {
                await _roleManager.CreateAsync(new AppRole()
                {
                    Name = role,
                    NormalizedName = role.ToUpper()
                });
            }
            return await _userManager.AddToRoleAsync(appUser, role);
        }

        public async Task<IdentityResult> CustomerRegisterAsync(CustomerRegisterDto customerRegisterDto)
        {
            AppUser appUser = new AppUser()
            {
                Email = customerRegisterDto.Email,
                PhoneNumber = customerRegisterDto.PhoneNumber,
                UserName = customerRegisterDto.UserName,
                FirstName = customerRegisterDto.FirstName,
                Address = customerRegisterDto.Address,
                LastName = customerRegisterDto.LastName
            };
            IdentityResult result = await _userManager.CreateAsync(appUser, customerRegisterDto.Password);
            Customer customer = new() { Id = appUser.Id };
            await _unitOfWork.CustomerDal.AddAsync(customer);
            await _unitOfWork.SaveAsync();
            if (result.Succeeded)
            {
                await AddToRoleAsync(appUser, "customer");
                await _unitOfWork.SaveAsync();
            }
            return result;
        }
        public async Task<IdentityResult> SellerRegisterAsync(SellerRegisterDto sellerRegisterDto)
        {
            AppUser appUser = new AppUser()
            {
                Email = sellerRegisterDto.Email,
                PhoneNumber = sellerRegisterDto.PhoneNumber,
                UserName = sellerRegisterDto.UserName,
                Address = sellerRegisterDto.Address,
                FirstName = sellerRegisterDto.FirstName,
                LastName = sellerRegisterDto.LastName
            };
            IdentityResult result = await _userManager.CreateAsync(appUser, sellerRegisterDto.Password);
            Seller seller = new Seller()
            {
                Id = appUser.Id,
                CompanyName = sellerRegisterDto.CompanyName,
            };
            await _unitOfWork.SellerDal.AddAsync(seller);
            await _unitOfWork.SaveAsync();

            if (result.Succeeded)
            {
                await AddToRoleAsync(appUser, "seller");
                await _unitOfWork.SaveAsync();
            }
            return result;
        }
        public async Task<SignInResult> LoginAsync(LoginDto loginDto)
        {
            AppUser user;
            if (loginDto.UserName.Contains("@"))
            {
                user = _userManager.Users.FirstOrDefault(x => x.Email == loginDto.UserName);
            }
            else
            {
                user = _userManager.Users.FirstOrDefault(x => x.UserName == loginDto.UserName);
            }
            return user is not null ? await _signInManager.PasswordSignInAsync(user, loginDto.Password, true, false) : null;
        }
        public async Task SignOutAsync() => await _signInManager.SignOutAsync();

        public async Task<IdentityResult> PasswordResetAsync(string userName, string newPassword)
        {
            string token = null;
            AppUser user = await GetUserAsync(userName);
            IdentityResult result = await _userManager.RemovePasswordAsync(user);
            if (result.Succeeded)
            {
                token = await _userManager.GeneratePasswordResetTokenAsync(user);
            }
            return await _userManager.ResetPasswordAsync(user, token, newPassword);
        }

        public async Task<IdentityResult> UpdatePasswordAsync(string userName, string currentPassword, string newPassword)
        {
            AppUser user = await GetUserAsync(userName);
            return await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        }

        public async Task<AppUser> GetUserAsync(string userName)
        {
            return await _userManager.Users.FirstOrDefaultAsync(x => !userName.Contains("@") ? x.UserName == userName : x.Email == userName);
        }

        public async Task<IdentityResult> RemoveUserAsync(string userName)
        {
            IdentityResult result = null;
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    AppUser user = await GetUserAsync(userName);
                    // gelen role gore seller veya customer silinecek.
                    Seller seller = await _unitOfWork.SellerDal.GetAsync(x => x.Id == user.Id);
                    result = await _userManager.DeleteAsync(user);
                    if (result.Succeeded)
                    {
                        await _unitOfWork.SellerDal.DeleteAsync(seller);
                        await _unitOfWork.SaveAsync();
                    }
                    ts.Complete();
                }
                catch (Exception)
                {
                    ts.Dispose();
                }
            }
            return result;
        }

        public async Task<List<string>> GetRolesAsync(AppUser user)
        {
            List<string> roles = (await _userManager.GetRolesAsync(user)).ToList();
            return roles;
        }
    }
}

using HizliSec.Business.Abstract;
using HizliSec.Entities.Concrete.Dtos.UserDtos;
using HizliSec.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace HizliSec.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AuthManager(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IdentityResult> AddToRoleAsync(AppUser appUser, string role)
        {

            AppRole appRole = _roleManager.Roles.FirstOrDefault(x => x.Name == role);
            if (appRole is null)
            {
                appRole = new AppRole()
                {
                    Name = role,
                    NormalizedName = role.ToUpper()
                };
                await _roleManager.CreateAsync(appRole);
            }
            return await _userManager.AddToRoleAsync(appUser, role);
        }
        private async Task<IdentityResult> CreateUser(AppUser appUser, string password) => await _userManager.CreateAsync(appUser, password);
        private async Task CustomerAddAsync(Customer customer)
        {
            await _unitOfWork.CustomerDal.AddAsync(customer);
            await _unitOfWork.SaveAsync();
        }
        private async Task SellerAddAsync(Seller seller)
        {
            await _unitOfWork.SellerDal.AddAsync(seller);
            await _unitOfWork.SaveAsync();
        }
        public async Task<IdentityResult> CustomerRegisterAsync(CustomerRegisterDto customerRegisterDto)
        => await Register<Customer, CustomerRegisterDto>(customerRegisterDto, customerRegisterDto.Password, "customer");
        public async Task<IdentityResult> SellerRegisterAsync(SellerRegisterDto sellerRegisterDto)
        => await Register<Seller, SellerRegisterDto>(sellerRegisterDto, sellerRegisterDto.Password, "seller");
        public async Task<IdentityResult> Register<TEntity, TDto>(TDto registerDto, string password, string role)
        {
            AppUser appUser = _mapper.Map<AppUser>(registerDto);
            IdentityResult result = await CreateUser(appUser, password);
            TEntity entity;
            if (result.Succeeded)
            {
                await AddToRoleAsync(appUser, role);
                switch (typeof(TEntity))
                {
                    case Type customerType when customerType == typeof(Customer):
                        entity = _mapper.Map<TEntity>(appUser);
                        await CustomerAddAsync(entity as Customer);
                        break;
                    case Type sellerType when sellerType == typeof(Seller):
                        entity = _mapper.Map<TEntity>(appUser);
                        await SellerAddAsync(entity as Seller);
                        break;
                    default:
                        break;
                }
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
            var user = await _userManager.Users.FirstOrDefaultAsync(x => !userName.Contains("@") ? x.UserName == userName : x.Email == userName);
            return user;
        }
        //public async Task<IdentityResult> RemoveUserAsync(string userName)
        //{
        //    IdentityResult result = null;
        //    using (TransactionScope ts = new TransactionScope())
        //    {
        //        try
        //        {
        //            AppUser user = await GetUserAsync(userName);
        //            // gelen role gore seller veya customer silinecek.
        //            Seller seller = await _unitOfWork.SellerDal.GetAsync(x => x.Id == user.Id);
        //            result = await _userManager.DeleteAsync(user);
        //            if (result.Succeeded)
        //            {
        //                await _unitOfWork.SellerDal.DeleteAsync(seller);
        //                await _unitOfWork.SaveAsync();
        //            }
        //            ts.Complete();
        //        }
        //        catch (Exception)
        //        {
        //            ts.Dispose();
        //        }
        //    }
        //    return result;
        //}
        public async Task<List<string>> GetRolesAsync(AppUser user)
        {
            List<string> roles = (await _userManager.GetRolesAsync(user)).ToList();
            return roles;
        }
    }
}

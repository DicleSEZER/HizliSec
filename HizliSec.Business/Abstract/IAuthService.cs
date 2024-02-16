using HizliSec.Entities.Concrete;
using HizliSec.Entities.Concrete.Dtos.UserDtos;
using Microsoft.AspNetCore.Identity;

namespace HizliSec.Business.Abstract
{
    public interface IAuthService
    {
        Task<List<string>> GetRolesAsync(AppUser user);
        //Task<IdentityResult> RemoveUserAsync(string userName);
        Task<AppUser> GetUserAsync(string userName);
        Task<IdentityResult> PasswordResetAsync(string userName, string newPassword);
        Task<IdentityResult> UpdatePasswordAsync(string userName, string currentPassword, string newPassword);
        Task<SignInResult> LoginAsync(LoginDto loginDto);
        Task<IdentityResult> SellerRegisterAsync(SellerRegisterDto sellerRegisterDto);
        Task<IdentityResult> CustomerRegisterAsync(CustomerRegisterDto customerRegisterDto);
        Task SignOutAsync();
        Task<IdentityResult> AddToRoleAsync(AppUser appUser, string role);
    }
}

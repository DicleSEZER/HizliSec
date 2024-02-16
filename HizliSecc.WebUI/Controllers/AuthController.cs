using HizliSec.Business.Abstract;
using HizliSec.Entities.Concrete.Dtos.UserDtos;

using Microsoft.AspNetCore.Mvc;

namespace HizliSecc.WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authservice;
        public AuthController(IAuthService authservice)
        {
            _authservice = authservice;
        }
        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Login(LoginDto loginDto)
        {
           Microsoft.AspNetCore.Identity.SignInResult response = await _authservice.LoginAsync(loginDto);
            return View();
        }
    }
}

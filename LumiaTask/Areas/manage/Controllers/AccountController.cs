using LumiaTask.Areas.manage.ViewModels;
using LumiaTask.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LumiaTask.Areas.manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
           _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginVM adminLoginVM)
        {
            if(!ModelState.IsValid) return View(); ;
            AppUser appUser =await _userManager.FindByNameAsync(adminLoginVM.UserName);
            if(appUser == null)
            {
                ModelState.AddModelError("", "Username or password is  incorrect");
                return View();
            }
            var result =await _signInManager.PasswordSignInAsync(appUser,adminLoginVM.Password,false,false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username or password is  incorrect");
                return View();
            }
            return RedirectToAction("index", "dashboard");
        }
        public async Task<IActionResult> Logout()
        {
           await _signInManager.SignOutAsync();
            return RedirectToAction("login", "account");
        }
    }
}

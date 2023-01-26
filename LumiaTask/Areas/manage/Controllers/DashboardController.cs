using LumiaTask.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LumiaTask.Areas.manage.Controllers
{
    [Area("manage")]
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DashboardController(UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        //public async Task<IActionResult> CreateAdmin()
        //{
        //    AppUser appUser = new AppUser
        //    {
        //        FullName = "Cekah hacili",
        //        UserName = "SuperAdmin"
        //    };
        //   await _userManager.CreateAsync(appUser,"Admin123");
        //    return Ok("AdminCreated");
        //}
        //public async Task<IActionResult> CreateRole()
        //{
        //    IdentityRole role1 = new IdentityRole("SuperAdmin");
        //    IdentityRole role2 = new IdentityRole("Admin");
        //    IdentityRole role3 = new IdentityRole("Member");
        //    await _roleManager.CreateAsync(role3);
        //    await _roleManager.CreateAsync(role2);
        //    await _roleManager.CreateAsync(role1);
        //    return Ok("RoleCreated");
        //}
        //public async Task<IActionResult> AddRole()
        //{
        //    AppUser admin =await _userManager.FindByNameAsync("SuperAdmin");
        //    await _userManager.AddToRoleAsync(admin, "SuperAdmin");
        //    return Ok("roleadded");
        //}
    }
}

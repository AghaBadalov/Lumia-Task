using LumiaTask.Models;
using Microsoft.AspNetCore.Identity;
using NuGet.Protocol.Core.Types;

namespace LumiaTask.Areas.manage.Services
{
    public class LayoutService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public LayoutService(UserManager<AppUser> userManager,IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }
        public  async Task<AppUser> GetUser()
        {
            AppUser appUser = null;
            string name =  _contextAccessor.HttpContext.User.Identity.Name;

            appUser = await _userManager.FindByNameAsync(name);
            return appUser;
        }
    }
}

using Microsoft.AspNetCore.Identity;

namespace LumiaTask.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}

using LumiaTask.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LumiaTask.DAL
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Setting> Settings { get; set; }


    }
}

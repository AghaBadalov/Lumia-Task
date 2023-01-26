using LumiaTask.DAL;
using LumiaTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LumiaTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<Team> teams = _dbContext.Teams.Include(x=>x.Profession).Where(x=>x.IsDeleted==false).ToList();

            return View(teams);
        }

        
    }
}
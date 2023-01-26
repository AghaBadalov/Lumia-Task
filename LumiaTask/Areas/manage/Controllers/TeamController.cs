using LumiaTask.DAL;
using LumiaTask.Helpers;
using LumiaTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;

namespace LumiaTask.Areas.manage.Controllers
{
    [Area("manage")]
    public class TeamController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public TeamController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Team> teams = _context.Teams.Include(x => x.Profession).ToList();
            return View(teams);
        }
        public IActionResult Create()
        {
            ViewBag.Professions=_context.Professions;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Team team)
        {
            ViewBag.Professions = _context.Professions;
            if (!ModelState.IsValid) return View(team);

            if(team.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Can't be null");
                return View();
            }
            if(team.ImageFile.ContentType!="image/png" && team.ImageFile.ContentType != "image/jpeg")
            {
                ModelState.AddModelError("ImageFile", "Wrong file type");
                return View();
            }
            if(team.ImageFile.Length> 2097152)
            {
                ModelState.AddModelError("ImageFile", "Only 2mb or lower files");
                return View();
            }

            team.ImageUrl = team.ImageFile.SaveFile(_env.WebRootPath, "uploads/teams");
            team.IsDeleted = false;
            _context.Teams.Add(team);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Update(int id)
        {
            ViewBag.Professions = _context.Professions;
            Team team=_context.Teams.FirstOrDefault(t => t.Id == id);
            if (team is null) return NotFound();
            return View(team);
        }
        [HttpPost]
        public IActionResult Update(Team team)
        {
            ViewBag.Professions = _context.Professions;

            Team exstteam = _context.Teams.FirstOrDefault(x => x.Id == team.Id);
            if(exstteam is null) return NotFound();
            if (!ModelState.IsValid)
            {
                return View(exstteam);
            }

            if (team.ImageFile != null)
            {
                string path = Path.Combine(_env.WebRootPath, "uploads/teams", exstteam.ImageUrl);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                if (team.ImageFile.ContentType != "image/png" && team.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "Wrong file type");
                    return View();
                }
                if (team.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "Only 2mb or lower files");
                    return View();
                }

                exstteam.ImageUrl = team.ImageFile.SaveFile(_env.WebRootPath, "uploads/teams");
            }
            exstteam.Profession = team.Profession;
            exstteam.Name = team.Name;
            exstteam.Desc = team.Desc;
            exstteam.IGUrl = team.IGUrl;
            exstteam.FBUrl = team.FBUrl;
            exstteam.TTUrl = team.TTUrl;
            exstteam.LNUrl = team.LNUrl;
            _context.SaveChanges();
            return RedirectToAction("index");


        }
        public IActionResult Delete(int id)
        {
            Team team = _context.Teams.FirstOrDefault(t => t.Id == id);
            if (team is null) return NotFound(); string path = Path.Combine(_env.WebRootPath, "uploads/teams", team.ImageUrl);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            _context.Teams.Remove(team);    
            _context.SaveChanges();
            return RedirectToAction("index");

        }
    }
}

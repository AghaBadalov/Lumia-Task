using LumiaTask.DAL;
using LumiaTask.Helpers;
using LumiaTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace LumiaTask.Areas.manage.Controllers
{
    [Area("manage")]
    public class SettingController : Controller
    {
        private readonly AppDbContext _context;

        public SettingController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page=1)
        {
            var query = _context.Settings.AsQueryable();
            PaginatedList<Setting> settings1 = PaginatedList<Setting>.Create(query, 2, page);
            List<Setting> settings = _context.Settings.ToList();
            return View(settings1);
        }
        public IActionResult Update(int id)
        {
            Setting setting = _context.Settings.FirstOrDefault(x => x.Id == id);
            if(setting == null) return NotFound();
            return View(setting);
        }
        [HttpPost]
        public IActionResult Update(Setting setting)
        {
            Setting exstsetting=_context.Settings.FirstOrDefault(x => x.Id == setting.Id);
            if(exstsetting == null) return NotFound();
            exstsetting.Value = setting.Value;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

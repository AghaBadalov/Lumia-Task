using LumiaTask.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LumiaTask.Controllers
{
    public class HomeController : Controller
    {
       

        public IActionResult Index()
        {
            return View();
        }

        
    }
}
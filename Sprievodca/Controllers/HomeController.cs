using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sprievodca.Data;
using System.Diagnostics;

namespace Sprievodca.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private SprievodcaDbContext _context;

        public HomeController(ILogger<HomeController> logger, SprievodcaDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        public IActionResult Index()
        {
            ViewBag.Regions = _context.Regions.ToList();
            ViewBag.Areas = _context.Areas.ToList();
            ViewBag.SubAreas = _context.SubAreas.ToList();
            ViewBag.Sectors = _context.Sectors.ToList();
            ViewBag.Routes = _context.Routes.ToList();



            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Admin() 
        { 
            return View();
        }
    }
}
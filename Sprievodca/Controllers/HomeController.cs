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
            ViewBag.kraj = _context.Kraj.ToList();
            ViewBag.oblast = _context.Oblast.ToList();
            ViewBag.podOblast = _context.PodOblast.ToList();
            ViewBag.sektor = _context.Sektor.ToList();
            ViewBag.Cesta = _context.Cesta.ToList();



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
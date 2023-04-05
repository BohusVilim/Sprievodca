using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sprievodca.Data;
using Sprievodca.Models.MainModels;

namespace Sprievodca.Controllers
{
    public class SectorController : Controller
    {
        private readonly SprievodcaDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public SectorController(SprievodcaDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Sector
        public async Task<IActionResult> Index()
        {
              return View(await _context.Sectors.Include(a => a.Area).Include(b => b.SubArea).Include(c => c.Routes).ToListAsync());
        }

        // GET: Sector/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Sectors == null)
            {
                return NotFound();
            }

            var sector = await _context.Sectors
                .Include(a => a.SubArea)
                .Include(b => b.Area)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sector == null)
            {
                return NotFound();
            }

            return View(sector);
        }

        // GET: Sector/Create
        public IActionResult Create()
        {
            var areas = _context.Areas.Where(a => a.ExistSubArea == false).ToList();
            ViewBag.Areas = new SelectList(areas, "Id", "Name");

            var subAreas = _context.SubAreas.ToList();
            ViewBag.SubAreas = new SelectList(subAreas, "Id", "Name");

            return View();
        }

        // POST: Sector/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ImageFile,ImageName,Area,AreaId,SubArea,SubAreaId")] Sector sector)
        {
            sector.Area = _context.Areas.Find(sector.AreaId);
            if (sector.Area == null)
            {
                sector.SubArea = _context.SubAreas.Find(sector.SubAreaId);
            }

            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(sector.ImageFile.FileName);
                string extension = Path.GetExtension(sector.ImageFile.FileName);
                sector.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/images/", fileName);
                string directoryPath = Path.GetDirectoryName(path);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await sector.ImageFile.CopyToAsync(fileStream);
                }

                sector.Routes = _context.Routes.Where(c => c.SectorId == sector.Id).ToList();

                _context.Add(sector);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var areas = _context.Areas.Where(a => a.ExistSubArea == false).ToList();
            ViewBag.Areas = new SelectList(areas, "Id", "Name", sector.AreaId);

            var subAreas = _context.SubAreas.ToList();
            ViewBag.SubAreas = new SelectList(subAreas, "Id", "Name", sector.SubAreaId);

            return View(sector);
        }

        // GET: Sector/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Sectors == null)
            {
                return NotFound();
            }

            var sector = await _context.Sectors.FindAsync(id);
            if (sector == null)
            {
                return NotFound();
            }
            return View(sector);
        }

        // POST: Sector/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,PictureURL,SubAreaId")] Sector sector)
        {
            if (id != sector.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sector);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SectorExists(sector.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sector);
        }

        // GET: Sector/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Sectors == null)
            {
                return NotFound();
            }

            var sector = await _context.Sectors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sector == null)
            {
                return NotFound();
            }

            return View(sector);
        }

        // POST: Sector/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Sectors == null)
            {
                return Problem("Entity set 'SprievodcaDbContext.Sector'  is null.");
            }
            var sector = await _context.Sectors.FindAsync(id);
            if (sector != null)
            {
                _context.Sectors.Remove(sector);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SectorExists(long id)
        {
          return _context.Sectors.Any(e => e.Id == id);
        }
    }
}

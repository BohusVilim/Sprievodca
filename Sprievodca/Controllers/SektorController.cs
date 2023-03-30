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
    public class SektorController : Controller
    {
        private readonly SprievodcaDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public SektorController(SprievodcaDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Sektor
        public async Task<IActionResult> Index()
        {
              return View(await _context.Sektor.Include(a => a.Oblast).Include(b => b.PodOblast).Include(c => c.Cesta).ToListAsync());
        }

        // GET: Sektor/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Sektor == null)
            {
                return NotFound();
            }

            var sektor = await _context.Sektor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sektor == null)
            {
                return NotFound();
            }

            return View(sektor);
        }

        // GET: Sektor/Create
        public IActionResult Create()
        {
            var oblasti = _context.Oblast.Where(a => a.ExistPodOblast == false).ToList();
            ViewBag.Oblasti = new SelectList(oblasti, "Id", "Name");

            var podOblasti = _context.PodOblast.ToList();
            ViewBag.PodOblasti = new SelectList(podOblasti, "Id", "Name");

            return View();
        }

        // POST: Sektor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ImageFile,ImageName,Oblast,OblastId,Oblast,PodOblastId")] Sektor sektor)
        {
            sektor.Oblast = _context.Oblast.Find(sektor.OblastId);
            if (sektor.Oblast == null)
            {
                sektor.PodOblast = _context.PodOblast.Find(sektor.PodOblastId);
            }

            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(sektor.ImageFile.FileName);
                string extension = Path.GetExtension(sektor.ImageFile.FileName);
                sektor.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/images/", fileName);
                string directoryPath = Path.GetDirectoryName(path);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await sektor.ImageFile.CopyToAsync(fileStream);
                }

                sektor.Cesta = _context.Cesta.Where(c => c.SektorId == sektor.Id).ToList();

                _context.Add(sektor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var oblasti = _context.Oblast.Where(a => a.ExistPodOblast == false).ToList();
            ViewBag.Oblasti = new SelectList(oblasti, "Id", "Name", sektor.OblastId);

            var podOblasti = _context.PodOblast.ToList();
            ViewBag.PodOblasti = new SelectList(podOblasti, "Id", "Name", sektor.PodOblastId);

            return View(sektor);
        }

        // GET: Sektor/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Sektor == null)
            {
                return NotFound();
            }

            var sektor = await _context.Sektor.FindAsync(id);
            if (sektor == null)
            {
                return NotFound();
            }
            return View(sektor);
        }

        // POST: Sektor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,PictureURL,PodOblastId")] Sektor sektor)
        {
            if (id != sektor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sektor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SektorExists(sektor.Id))
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
            return View(sektor);
        }

        // GET: Sektor/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Sektor == null)
            {
                return NotFound();
            }

            var sektor = await _context.Sektor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sektor == null)
            {
                return NotFound();
            }

            return View(sektor);
        }

        // POST: Sektor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Sektor == null)
            {
                return Problem("Entity set 'SprievodcaDbContext.Sektor'  is null.");
            }
            var sektor = await _context.Sektor.FindAsync(id);
            if (sektor != null)
            {
                _context.Sektor.Remove(sektor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SektorExists(long id)
        {
          return _context.Sektor.Any(e => e.Id == id);
        }
    }
}

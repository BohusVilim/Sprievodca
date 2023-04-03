using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sprievodca.Data;
using Sprievodca.Models.MainModels;

namespace Sprievodca.Controllers
{
    public class PodOblastController : Controller
    {
        private readonly SprievodcaDbContext _context;

        public PodOblastController(SprievodcaDbContext context)
        {
            _context = context;
        }

        // GET: PodOblast
        public async Task<IActionResult> Index()
        {
              return View(await _context.PodOblast.Include(a => a.Oblast).Include(b => b.Sektor).ToListAsync());
        }

        // GET: PodOblast/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.PodOblast == null)
            {
                return NotFound();
            }

            var podOblast = await _context.PodOblast.Include(a => a.Sektor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (podOblast == null)
            {
                return NotFound();
            }

            return View(podOblast);
        }

        // GET: PodOblast/Create
        public IActionResult Create()
        {
            var oblasti = _context.Oblast.ToList();
            ViewBag.Oblasti = new SelectList(oblasti, "Id", "Name");

            return View();
        }

        // POST: PodOblast/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Sektor,Oblast,OblastId")] PodOblast podOblast)
        {
            podOblast.Oblast = _context.Oblast.Find(podOblast.OblastId);

            ModelState.Remove("Oblast");
            if (ModelState.IsValid)
            {
                _context.Add(podOblast);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var oblasti = _context.Oblast.ToList();
            ViewBag.Oblasti = new SelectList(oblasti, "Id", "Nazov", podOblast.OblastId);

            return View(podOblast);
        }

        // GET: PodOblast/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.PodOblast == null)
            {
                return NotFound();
            }

            var podOblast = await _context.PodOblast.FindAsync(id);
            if (podOblast == null)
            {
                return NotFound();
            }
            return View(podOblast);
        }

        // POST: PodOblast/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name")] PodOblast podOblast)
        {
            if (id != podOblast.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(podOblast);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PodOblastExists(podOblast.Id))
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
            return View(podOblast);
        }

        // GET: PodOblast/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.PodOblast == null)
            {
                return NotFound();
            }

            var podOblast = await _context.PodOblast
                .FirstOrDefaultAsync(m => m.Id == id);
            if (podOblast == null)
            {
                return NotFound();
            }

            return View(podOblast);
        }

        // POST: PodOblast/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.PodOblast == null)
            {
                return Problem("Entity set 'SprievodcaDbContext.PodOblast'  is null.");
            }
            var podOblast = await _context.PodOblast.FindAsync(id);
            if (podOblast != null)
            {
                _context.PodOblast.Remove(podOblast);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PodOblastExists(long id)
        {
          return _context.PodOblast.Any(e => e.Id == id);
        }
    }
}

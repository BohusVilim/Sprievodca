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
    public class CestaController : Controller
    {
        private readonly SprievodcaDbContext _context;

        public CestaController(SprievodcaDbContext context)
        {
            _context = context;
        }

        // GET: Cesta
        public async Task<IActionResult> Index()
        {
              return View(await _context.Cesta.Include(a => a.Sektor).ToListAsync());
        }

        // GET: Cesta/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Cesta == null)
            {
                return NotFound();
            }

            var cesta = await _context.Cesta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cesta == null)
            {
                return NotFound();
            }

            return View(cesta);
        }

        // GET: Cesta/Create
        public IActionResult Create()
        {
            var sektory = _context.Sektor.ToList();
            ViewBag.Sektory = new SelectList(sektory, "Id", "Name");

            return View();
        }

        // POST: Cesta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,Name,Grade,Lenght,Style,Description,Author,Year,Sektor,SektorId")] Cesta cesta)
        {

            cesta.Sektor = _context.Sektor.Find(cesta.SektorId);

            ModelState.Remove("Sektor");
            if (ModelState.IsValid)
            {
                _context.Add(cesta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var sektory = _context.Sektor.ToList();
            ViewBag.Sektory = new SelectList(sektory, "Id", "Name", cesta.SektorId);

            return View(cesta);
        }

        // GET: Cesta/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Cesta == null)
            {
                return NotFound();
            }

            var cesta = await _context.Cesta.FindAsync(id);
            if (cesta == null)
            {
                return NotFound();
            }
            return View(cesta);
        }

        // POST: Cesta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Grade,Lenght,Style,Description,Author,SektorId")] Cesta cesta)
        {
            if (id != cesta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cesta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CestaExists(cesta.Id))
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
            return View(cesta);
        }

        // GET: Cesta/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Cesta == null)
            {
                return NotFound();
            }

            var cesta = await _context.Cesta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cesta == null)
            {
                return NotFound();
            }

            return View(cesta);
        }

        // POST: Cesta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Cesta == null)
            {
                return Problem("Entity set 'SprievodcaDbContext.Cesta'  is null.");
            }
            var cesta = await _context.Cesta.FindAsync(id);
            if (cesta != null)
            {
                _context.Cesta.Remove(cesta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CestaExists(long id)
        {
          return _context.Cesta.Any(e => e.Id == id);
        }
    }
}

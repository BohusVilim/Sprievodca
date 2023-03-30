using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Sprievodca.Data;
using Sprievodca.Models.MainModels;

namespace Sprievodca.Controllers
{
    public class OblastController : Controller
    {
        private readonly SprievodcaDbContext _context;

        public OblastController(SprievodcaDbContext context)
        {
            _context = context;
        }

        // GET: Oblast
        public async Task<IActionResult> Index()
        {
            return View(await _context.Oblast.Include(a => a.Kraj).Include(b => b.PodOblast).Include(c => c.Sektor).ToListAsync());
        }

        // GET: Oblast/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Oblast == null)
            {
                return NotFound();
            }

            var oblast = await _context.Oblast
                .Include(a => a.Kraj)
                .Include(b => b.PodOblast)
                .Include(c => c.Sektor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oblast == null)
            {
                return NotFound();
            }

            return View(oblast);
        }

        // GET: Oblast/Create
        public IActionResult Create()
        {
            var kraje = _context.Kraj.ToList();
            ViewBag.Kraje = new SelectList(kraje, "Id", "Nazov");

            return View();
        }

        // POST: Oblast/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,PodOblast,Kraj,KrajId,ExistPodOblast,Sektor")] Oblast oblast)
        {
            oblast.Kraj = _context.Kraj.Find(oblast.KrajId);

            ModelState.Remove("Kraj");
            if (ModelState.IsValid)
            {
                if (ModelState["ExistPodOblast"].AttemptedValue != "false")
                {
                    oblast.ExistPodOblast = true;
                }
                else
                {
                    oblast.ExistPodOblast = false;
                }

                oblast.Sektor = _context.Sektor.Where(a => a.OblastId == oblast.Id).ToList();

                _context.Add(oblast);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            var kraje = _context.Kraj.ToList();
            ViewBag.Kraje = new SelectList(kraje, "Id", "Nazov", oblast.KrajId);

            return View(oblast);
        }

        // GET: Oblast/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Oblast == null)
            {
                return NotFound();
            }

            var oblast = await _context.Oblast.FindAsync(id);
            if (oblast == null)
            {
                return NotFound();
            }

            var kraje = _context.Kraj.ToList();
            ViewBag.KrajeInEdit = new SelectList(kraje, "Id", "Nazov");

            return View(oblast);
        }

        // POST: Oblast/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Kraj,KrajId")] Oblast oblast)
        {
            if (id != oblast.Id)
            {
                return NotFound();
            }

            oblast.Kraj = _context.Kraj.Find(oblast.KrajId);

            ModelState.Remove("Kraj");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oblast);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OblastExists(oblast.Id))
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

            var kraje = _context.Kraj.ToList();
            ViewBag.KrajeInEdit = new SelectList(kraje, "Id", "Nazov");

            return View(oblast);
        }

        // GET: Oblast/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Oblast == null)
            {
                return NotFound();
            }

            var oblast = await _context.Oblast
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oblast == null)
            {
                return NotFound();
            }

            return View(oblast);
        }

        // POST: Oblast/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Oblast == null)
            {
                return Problem("Entity set 'SprievodcaDbContext.Oblast'  is null.");
            }
            var oblast = await _context.Oblast.FindAsync(id);
            if (oblast != null)
            {
                _context.Oblast.Remove(oblast);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OblastExists(long id)
        {
          return _context.Oblast.Any(e => e.Id == id);
        }
    }
}

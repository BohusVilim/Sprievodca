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
    public class SubAreaController : Controller
    {
        private readonly SprievodcaDbContext _context;

        public SubAreaController(SprievodcaDbContext context)
        {
            _context = context;
        }

        // GET: SubArea
        public async Task<IActionResult> Index()
        {
              return View(await _context.SubAreas.Include(a => a.Area).Include(b => b.Sectors).ToListAsync());
        }

        // GET: SubArea/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.SubAreas == null)
            {
                return NotFound();
            }

            var subArea = await _context.SubAreas.Include(a => a.Sectors)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subArea == null)
            {
                return NotFound();
            }

            return View(subArea);
        }

        // GET: SubArea/Create
        public IActionResult Create()
        {
            var areas = _context.Areas.Where(a => a.ExistSubArea == true).ToList();
            ViewBag.Areas = new SelectList(areas, "Id", "Name");

            return View();
        }

        // POST: SubArea/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Sectors,Area,AreaId")] SubArea subArea)
        {
            subArea.Area = _context.Areas.Find(subArea.AreaId);

            ModelState.Remove("Area");
            if (ModelState.IsValid)
            {
                _context.Add(subArea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var areas = _context.Areas.Where(a => a.ExistSubArea == true).ToList();
            ViewBag.Areas = new SelectList(areas, "Id", "Name", subArea.AreaId);

            return View(subArea);
        }

        // GET: SubArea/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.SubAreas == null)
            {
                return NotFound();
            }

            var subArea = await _context.SubAreas.FindAsync(id);
            if (subArea == null)
            {
                return NotFound();
            }
            return View(subArea);
        }

        // POST: SubArea/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name")] SubArea subArea)
        {
            if (id != subArea.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subArea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubAreaExists(subArea.Id))
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
            return View(subArea);
        }

        // GET: SubArea/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.SubAreas == null)
            {
                return NotFound();
            }

            var subArea = await _context.SubAreas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subArea == null)
            {
                return NotFound();
            }

            return View(subArea);
        }

        // POST: SubArea/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.SubAreas == null)
            {
                return Problem("Entity set 'SprievodcaDbContext.SubArea'  is null.");
            }
            var subArea = await _context.SubAreas.FindAsync(id);
            if (subArea != null)
            {
                _context.SubAreas.Remove(subArea);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubAreaExists(long id)
        {
          return _context.SubAreas.Any(e => e.Id == id);
        }
    }
}

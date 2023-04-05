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
    public class AreaController : Controller
    {
        private readonly SprievodcaDbContext _context;

        public AreaController(SprievodcaDbContext context)
        {
            _context = context;
        }

        // GET: Area
        public async Task<IActionResult> Index()
        {
            return View(await _context.Areas.Include(a => a.Region).Include(b => b.SubArea).Include(c => c.Sector).ToListAsync());
        }

        // GET: Area/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Areas == null)
            {
                return NotFound();
            }

            var area = await _context.Areas
                .Include(a => a.Region)
                .Include(b => b.SubArea)
                .Include(c => c.Sector)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (area == null)
            {
                return NotFound();
            }

            return View(area);
        }

        // GET: Area/Create
        public IActionResult Create()
        {
            var regions = _context.Regions.ToList();
            ViewBag.Regions = new SelectList(regions, "Id", "Name");

            return View();
        }

        // POST: Area/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,SubArea,Region,RegionId,ExistSubArea,Sector")] Area area)
        {
            area.Region = _context.Regions.Find(area.RegionId);

            ModelState.Remove("Region");
            if (ModelState.IsValid)
            {
                if (ModelState["ExistSubArea"].AttemptedValue != "false")
                {
                    area.ExistSubArea = true;
                }
                else
                {
                    area.ExistSubArea = false;
                }

                area.Sector = _context.Sectors.Where(a => a.AreaId == area.Id).ToList();

                _context.Add(area);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            var regions = _context.Regions.ToList();
            ViewBag.Regions = new SelectList(regions, "Id", "Name", area.RegionId);

            return View(area);
        }

        // GET: Area/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Areas == null)
            {
                return NotFound();
            }

            var area = await _context.Areas.FindAsync(id);
            if (area == null)
            {
                return NotFound();
            }

            var regions = _context.Regions.ToList();
            ViewBag.RegionsInEdit = new SelectList(regions, "Id", "Name");

            return View(area);
        }

        // POST: Area/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Region,RegionId")] Area area)
        {
            if (id != area.Id)
            {
                return NotFound();
            }

            area.Region = _context.Regions.Find(area.RegionId);

            ModelState.Remove("Region");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(area);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AreaExists(area.Id))
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

            var regions = _context.Regions.ToList();
            ViewBag.RegionsInEdit = new SelectList(regions, "Id", "Name");

            return View(area);
        }

        // GET: Area/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Areas == null)
            {
                return NotFound();
            }

            var areas = await _context.Areas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (areas == null)
            {
                return NotFound();
            }

            return View(areas);
        }

        // POST: Area/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Areas == null)
            {
                return Problem("Entity set 'SprievodcaDbContext.Areas'  is null.");
            }
            var area = await _context.Areas.FindAsync(id);
            if (area != null)
            {
                _context.Areas.Remove(area);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AreaExists(long id)
        {
          return _context.Areas.Any(e => e.Id == id);
        }
    }
}

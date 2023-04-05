using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sprievodca.Data;
using Sprievodca.Models.MainModels;
using Sprievodca.Models.Shared;

namespace Sprievodca.Controllers
{
    public class RegionController : Controller
    {
        private readonly SprievodcaDbContext _context;

        public RegionController(SprievodcaDbContext context)
        {
            _context = context;
        }

        // GET: Kraj
        public async Task<IActionResult> Index()
        {

           return View(await _context.Regions.Include(a => a.Areas).ToListAsync());
        }

        // GET: Kraj/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Regions == null)
            {
                return NotFound();
            }

            var regions = await _context.Regions
                .Include(a => a.Areas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regions == null)
            {
                return NotFound();
            }

            return View(regions);
        }

        
        // GET: Kraj/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Regions == null)
            {
                return NotFound();
            }

            var regions = await _context.Regions.FindAsync(id);
            if (regions == null)
            {
                return NotFound();
            }
            return View(regions);
        }

        // POST: Kraj/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Nazov")] Region region)
        {
            if (id != region.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(region);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KrajExists(region.Id))
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
            return View(region);
        }

        private bool KrajExists(long id)
        {
          return _context.Regions.Any(e => e.Id == id);
        }
    }
}

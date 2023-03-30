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
    public class KrajController : Controller
    {
        private readonly SprievodcaDbContext _context;

        public KrajController(SprievodcaDbContext context)
        {
            _context = context;
        }

        // GET: Kraj
        public async Task<IActionResult> Index()
        {

           return View(await _context.Kraj.Include(a => a.Oblast).ToListAsync());
        }

        // GET: Kraj/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Kraj == null)
            {
                return NotFound();
            }

            var kraj = await _context.Kraj
                .Include(a => a.Oblast)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kraj == null)
            {
                return NotFound();
            }

            return View(kraj);
        }

        
        // GET: Kraj/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Kraj == null)
            {
                return NotFound();
            }

            var kraj = await _context.Kraj.FindAsync(id);
            if (kraj == null)
            {
                return NotFound();
            }
            return View(kraj);
        }

        // POST: Kraj/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Nazov")] Kraj kraj)
        {
            if (id != kraj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kraj);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KrajExists(kraj.Id))
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
            return View(kraj);
        }

        private bool KrajExists(long id)
        {
          return _context.Kraj.Any(e => e.Id == id);
        }
    }
}

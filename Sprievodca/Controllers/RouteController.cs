using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sprievodca.Data;
using Sprievodca.Models.MainModels;
using Sprievodca.Repositories.Routes;

namespace Sprievodca.Controllers
{
    public class RouteController : Controller
    {
        private readonly SprievodcaDbContext _context;

        public RouteController(SprievodcaDbContext context)
        {
            _context = context;
        }

        // GET: Cesta
        public async Task<IActionResult> Index()
        {
              return View(await _context.Routes.Include(a => a.Sector).ToListAsync());
        }

        // GET: Cesta/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Routes == null)
            {
                return NotFound();
            }

            var routes = await _context.Routes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (routes == null)
            {
                return NotFound();
            }

            return View(routes);
        }

        // GET: Cesta/Create
        public IActionResult Create()
        {
            var sektory = _context.Sectors.ToList();
            ViewBag.Sektory = new SelectList(sektory, "Id", "Name");

            return View();
        }

        // POST: Cesta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,Name,Grade,Lenght,Style,Description,Author,Year,Sector,SectorId")] Models.MainModels.Route route)
        {

            route.Sector = _context.Sectors.Find(route.SectorId);

            ModelState.Remove("Sector");
            if (ModelState.IsValid)
            {
                _context.Add(route);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var sektory = _context.Sectors.ToList();
            ViewBag.Sektory = new SelectList(sektory, "Id", "Name", route.SectorId);

            return View(route);
        }

        // GET: Cesta/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Routes == null)
            {
                return NotFound();
            }

            var routes = await _context.Routes.FindAsync(id);
            if (routes == null)
            {
                return NotFound();
            }
            return View(routes);
        }

        // POST: Cesta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Grade,Lenght,Style,Description,Author,SektorId")] Models.MainModels.Route route)
        {
            if (id != route.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(route);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RouteExists(route.Id))
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
            return View(route);
        }

        // GET: Cesta/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Routes == null)
            {
                return NotFound();
            }

            var route = await _context.Routes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (route == null)
            {
                return NotFound();
            }

            return View(route);
        }

        // POST: Cesta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Routes == null)
            {
                return Problem("Entity set 'SprievodcaDbContext.Cesta'  is null.");
            }
            var route = await _context.Routes.FindAsync(id);
            if (route != null)
            {
                _context.Routes.Remove(route);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RouteExists(long id)
        {
          return _context.Routes.Any(e => e.Id == id);
        }
    }
}

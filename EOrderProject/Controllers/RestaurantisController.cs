using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EOrderProject.Data;
using EOrderProject.Models;

namespace EOrderProject.Controllers
{
    public class RestaurantisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RestaurantisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Restaurantis
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Restaurantis.Include(r => r.Pikas);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Restaurantis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Restaurantis == null)
            {
                return NotFound();
            }

            var restauranti = await _context.Restaurantis
                .Include(r => r.Pikas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (restauranti == null)
            {
                return NotFound();
            }

            return View(restauranti);
        }

        // GET: Restaurantis/Create
        public IActionResult Create()
        {
            ViewData["PikatId"] = new SelectList(_context.Pikas, "Id", "Id");
            return View();
        }

        // POST: Restaurantis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,PikatId")] Restauranti restauranti)
        {
            if (ModelState.IsValid)
            {
                _context.Add(restauranti);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PikatId"] = new SelectList(_context.Pikas, "Id", "Id", restauranti.PikatId);
            return View(restauranti);
        }

        // GET: Restaurantis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Restaurantis == null)
            {
                return NotFound();
            }

            var restauranti = await _context.Restaurantis.FindAsync(id);
            if (restauranti == null)
            {
                return NotFound();
            }
            ViewData["PikatId"] = new SelectList(_context.Pikas, "Id", "Id", restauranti.PikatId);
            return View(restauranti);
        }

        // POST: Restaurantis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,PikatId")] Restauranti restauranti)
        {
            if (id != restauranti.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(restauranti);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestaurantiExists(restauranti.Id))
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
            ViewData["PikatId"] = new SelectList(_context.Pikas, "Id", "Id", restauranti.PikatId);
            return View(restauranti);
        }

        // GET: Restaurantis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Restaurantis == null)
            {
                return NotFound();
            }

            var restauranti = await _context.Restaurantis
                .Include(r => r.Pikas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (restauranti == null)
            {
                return NotFound();
            }

            return View(restauranti);
        }

        // POST: Restaurantis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Restaurantis == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Restaurantis'  is null.");
            }
            var restauranti = await _context.Restaurantis.FindAsync(id);
            if (restauranti != null)
            {
                _context.Restaurantis.Remove(restauranti);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RestaurantiExists(int id)
        {
          return _context.Restaurantis.Any(e => e.Id == id);
        }
    }
}

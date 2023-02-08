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
    public class PikatsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PikatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pikats
        public async Task<IActionResult> Index()
        {
              return View(await _context.Pikas.ToListAsync());
        }

        // GET: Pikats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pikas == null)
            {
                return NotFound();
            }

            var pikat = await _context.Pikas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pikat == null)
            {
                return NotFound();
            }

            return View(pikat);
        }

        // GET: Pikats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pikats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Qyteti,Info")] Pikat pikat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pikat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pikat);
        }

        // GET: Pikats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pikas == null)
            {
                return NotFound();
            }

            var pikat = await _context.Pikas.FindAsync(id);
            if (pikat == null)
            {
                return NotFound();
            }
            return View(pikat);
        }

        // POST: Pikats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Qyteti,Info")] Pikat pikat)
        {
            if (id != pikat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pikat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PikatExists(pikat.Id))
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
            return View(pikat);
        }

        // GET: Pikats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pikas == null)
            {
                return NotFound();
            }

            var pikat = await _context.Pikas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pikat == null)
            {
                return NotFound();
            }

            return View(pikat);
        }

        // POST: Pikats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pikas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Pikas'  is null.");
            }
            var pikat = await _context.Pikas.FindAsync(id);
            if (pikat != null)
            {
                _context.Pikas.Remove(pikat);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PikatExists(int id)
        {
          return _context.Pikas.Any(e => e.Id == id);
        }
    }
}

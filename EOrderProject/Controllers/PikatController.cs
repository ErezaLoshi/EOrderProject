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
    public class PikatController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PikatController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pikat
        public async Task<IActionResult> Index()
        {
              return View(await _context.Pikat.ToListAsync());
        }

        // GET: Pikat/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pikat == null)
            {
                return NotFound();
            }

            var pika = await _context.Pikat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pika == null)
            {
                return NotFound();
            }

            return View(pika);
        }

        // GET: Pikat/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pikat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Qyteti,Info")] Pika pika)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pika);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pika);
        }

        // GET: Pikat/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pikat == null)
            {
                return NotFound();
            }

            var pika = await _context.Pikat.FindAsync(id);
            if (pika == null)
            {
                return NotFound();
            }
            return View(pika);
        }

        // POST: Pikat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Qyteti,Info")] Pika pika)
        {
            if (id != pika.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pika);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PikaExists(pika.Id))
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
            return View(pika);
        }

        // GET: Pikat/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pikat == null)
            {
                return NotFound();
            }

            var pika = await _context.Pikat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pika == null)
            {
                return NotFound();
            }

            return View(pika);
        }

        // POST: Pikat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pikat == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Pikat'  is null.");
            }
            var pika = await _context.Pikat.FindAsync(id);
            if (pika != null)
            {
                _context.Pikat.Remove(pika);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PikaExists(int id)
        {
          return _context.Pikat.Any(e => e.Id == id);
        }
    }
}

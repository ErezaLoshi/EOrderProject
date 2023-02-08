using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EOrderProject.Data;
using EOrderProject.Models;
using EOrderProject.Data.Services;
using EOrderProject.Data.Migrations;

namespace EOrderProject.Controllers
{
    public class PikatEShitjesController : Controller
    {
        private readonly IPikatEShitjesService _service;

        private readonly IWebHostEnvironment _iwebhost;

        public PikatEShitjesController(IPikatEShitjesService service, IWebHostEnvironment iwebhost)
        {
            _service = service;
            _iwebhost = iwebhost;
        }

        // GET: Menus
        public async Task<IActionResult> Index(string sortOrder, /*string currentFilter*/ string searchString /*int? pageNumber*/)
        {
            ViewData["CitySortParm"] = String.IsNullOrEmpty(sortOrder) ? "city_desc" : "";
            ViewData["InfoSortParm"] = String.IsNullOrEmpty(sortOrder) ? "info_desc" : "";
            ViewData["CurrentFilter"] = searchString;

            //if (searchString != null)
            //{
            //    pageNumber = 1;
            //}
            //else
            //{
            //    searchString = currentFilter;
            //}

            var pikatEShitjes = from s in await _service.GetAllAsync()
                                select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                pikatEShitjes = pikatEShitjes.Where(s => s.City.Contains(searchString)
                                    || s.Info.Contains(searchString));      
            }
            switch (sortOrder)
            {
                case "city_desc":
                    pikatEShitjes = pikatEShitjes.OrderByDescending(s => s.City);
                    break;
                case "Info":
                    pikatEShitjes = pikatEShitjes.OrderByDescending(s => s.Info);
                    break;
                case "info_desc":
                    pikatEShitjes = pikatEShitjes.OrderByDescending(s => s.Info);
                    break;

                default:
                    pikatEShitjes = pikatEShitjes.OrderBy(s =>s. City);
                    break;
            }
            //int pageSize = 3;
            return View(pikatEShitjes);
        }




        //// GET: Staffs/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var pikatEShitjesDetails = await _service.GetByIdAsync(id);

            if (pikatEShitjesDetails == null) return View("NotFound");


            return View(pikatEShitjesDetails);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Menus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public async Task<IActionResult> Create([Bind("Id,Image,City,Info")] PikatEShitjes pikatEShitjes, IFormFile ifile, PikatEShitjes ic)
        {
            int error = 0;
            string imgext = Path.GetExtension(ifile.FileName);
            Guid guid = Guid.NewGuid();
            string imgname = guid.ToString() + imgext;
            var saveimg = Path.Combine(_iwebhost.WebRootPath, "images", imgname);

            if (imgext == ".jpg" || imgext == ".png")
            {
                var stream = new FileStream(saveimg, FileMode.Create);
                await ifile.CopyToAsync(stream);
            }
            else
            {
                error++;
            }

            if (error == 0)
            {
                pikatEShitjes.Image = imgname;
                await _service.AddAsync(pikatEShitjes);

                TempData["AlertMessage"] = "Item inserted successfully!";

                return new RedirectResult(Url.Action("Index") + "#pikatEShitjes");
            }
            else
            {
                TempData["ErrorMessage"] = "Please insert an image file!";

                return View(pikatEShitjes);
            }

        }

        //GET: menus/edit/$id
        public async Task<IActionResult> Edit(int id)
        {
            var pikatEShitjesDetails = await _service.GetByIdAsync(id);
            if (pikatEShitjesDetails == null) return View("NotFound");
            return View(pikatEShitjesDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Image,City,Info")] PikatEShitjes pikatEShitjes, IFormFile ifile, PikatEShitjes ic)
        {
            int error = 0;
            string imgext = Path.GetExtension(ifile.FileName);
            Guid guid = Guid.NewGuid();
            string newimgname = guid.ToString() + imgext;
            var saveimg = Path.Combine(_iwebhost.WebRootPath, "images", newimgname);

            if (imgext == ".jpg" || imgext == ".png")
            {
                var stream = new FileStream(saveimg, FileMode.Create);
                await ifile.CopyToAsync(stream);
            }
            else
            {
                error++;
            }


            if (id == pikatEShitjes.Id && error == 0)
            {
                pikatEShitjes.Image = newimgname;
                await _service.UpdateAsync(id, pikatEShitjes);
                TempData["AlertMessage"] = "Item edited successfully!";
                return new RedirectResult(Url.Action("Index") + "#pikatEShitjes");
            }
            else
            {
                TempData["ErrorMessage"] = "Please insert an image file!";
                return View(pikatEShitjes);
            }

        }


        //GET: pizzas/delete/$id
        public async Task<IActionResult> Delete(int id)
        {
            var pikatEShitjesDetails = await _service.GetByIdAsync(id);
            if (pikatEShitjesDetails == null) return View("NotFound");
            return View(pikatEShitjesDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id, IFormFile ifile, PikatEShitjes ic)
        {

            var pikatEShitjesDetails = await _service.GetByIdAsync(id);
            if (pikatEShitjesDetails == null) return View("NotFound");


            await _service.DeleteAsync(id);
            TempData["AlertMessage"] = "Item deleted successfully!";

            return new RedirectResult(Url.Action("Index") + "#pikatEShitjes");
        }
    }
}
        //private readonly ApplicationDbContext _context;

//        public PikatEShitjesController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        // GET: PikatEShitjes
//        public async Task<IActionResult> Index()
//        {
//              return View(await _context.PikatEShitjes.ToListAsync());
//        }

//        // GET: PikatEShitjes/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.PikatEShitjes == null)
//            {
//                return NotFound();
//            }

//            var pikatEShitjes = await _context.PikatEShitjes
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (pikatEShitjes == null)
//            {
//                return NotFound();
//            }

//            return View(pikatEShitjes);
//        }

//        // GET: PikatEShitjes/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: PikatEShitjes/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,Image,City,Info")] PikatEShitjes pikatEShitjes)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(pikatEShitjes);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(pikatEShitjes);
//        }

//        // GET: PikatEShitjes/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.PikatEShitjes == null)
//            {
//                return NotFound();
//            }

//            var pikatEShitjes = await _context.PikatEShitjes.FindAsync(id);
//            if (pikatEShitjes == null)
//            {
//                return NotFound();
//            }
//            return View(pikatEShitjes);
//        }

//        // POST: PikatEShitjes/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,Image,City,Info")] PikatEShitjes pikatEShitjes)
//        {
//            if (id != pikatEShitjes.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(pikatEShitjes);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!PikatEShitjesExists(pikatEShitjes.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(pikatEShitjes);
//        }

//        // GET: PikatEShitjes/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.PikatEShitjes == null)
//            {
//                return NotFound();
//            }

//            var pikatEShitjes = await _context.PikatEShitjes
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (pikatEShitjes == null)
//            {
//                return NotFound();
//            }

//            return View(pikatEShitjes);
//        }

//        // POST: PikatEShitjes/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.PikatEShitjes == null)
//            {
//                return Problem("Entity set 'ApplicationDbContext.PikatEShitjes'  is null.");
//            }
//            var pikatEShitjes = await _context.PikatEShitjes.FindAsync(id);
//            if (pikatEShitjes != null)
//            {
//                _context.PikatEShitjes.Remove(pikatEShitjes);
//            }
            
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool PikatEShitjesExists(int id)
//        {
//          return _context.PikatEShitjes.Any(e => e.Id == id);
//        }
//    }
//}

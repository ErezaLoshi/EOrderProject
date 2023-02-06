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

namespace EOrderProject.Controllers
{
    public class ComingSoonController : Controller
    {
        private readonly IComingSoonService _service;

        private readonly IWebHostEnvironment _iwebhost;

        public ComingSoonController(IComingSoonService service, IWebHostEnvironment iwebhost)
        {
            _service = service;
            _iwebhost = iwebhost;
        }

        // GET: Menus
        public async Task<IActionResult> Index(string sortOrder, /*string currentFilter*/ string searchString /*int? pageNumber*/)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
           // ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
            ViewData["CurrentFilter"] = searchString;

            //if (searchString != null)
            //{
            //    pageNumber = 1;
            //}
            //else
            //{
            //    searchString = currentFilter;
            //}

            var comingSoon = from s in await _service.GetAllAsync()
                        select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                comingSoon = comingSoon.Where(s => s.Name.Contains(searchString)
                                           );
            }
            switch (sortOrder)
            {
                case "name_desc":
                    comingSoon = comingSoon.OrderByDescending(s => s.Name);
                    break;
                case "Price":
                //    comingSoon = comingSoon.OrderBy(s => s.Price);
                //    break;
                //case "price_desc":
                //    comingSoon = comingSoon.OrderByDescending(s => s.Price);
                //    break;
            
                default:
                    comingSoon = comingSoon.OrderBy(s => s.Name);
                    break;
            }
            //int pageSize = 3;
            return View(comingSoon);
        }




        //// GET: Staffs/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var comingSoonDetails = await _service.GetByIdAsync(id);

            if (comingSoonDetails == null) return View("NotFound");


            return View(comingSoonDetails);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Menus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public async Task<IActionResult> Create([Bind("Id,Image,Name,Description")] ComingSoon comingSoon, IFormFile ifile, Menu ic)
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
                comingSoon.Image = imgname;
                await _service.AddAsync(comingSoon);

                TempData["AlertMessage"] = "Item inserted successfully!";

                return new RedirectResult(Url.Action("Index") + "#comingSoon");
            }
            else
            {
                TempData["ErrorMessage"] = "Please insert an image file!";

                return View(comingSoon);
            }

        }

        //GET: menus/edit/$id
        public async Task<IActionResult> Edit(int id)
        {
            var comingSoonDetails = await _service.GetByIdAsync(id);
            if (comingSoonDetails == null) return View("NotFound");
            return View(comingSoonDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Image,Name,Description")] ComingSoon comingSoon, IFormFile ifile, ComingSoon ic)
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


            if (id == comingSoon.Id && error == 0)
            {
                comingSoon.Image = newimgname;
                await _service.UpdateAsync(id, comingSoon);
                TempData["AlertMessage"] = "Item edited successfully!";
                return new RedirectResult(Url.Action("Index") + "#menu");
            }
            else
            {
                TempData["ErrorMessage"] = "Please insert an image file!";
                return View(comingSoon);
            }

        }


        //GET: pizzas/delete/$id
        public async Task<IActionResult> Delete(int id)
        {
            var comingSoonDetails = await _service.GetByIdAsync(id);
            if (comingSoonDetails == null) return View("NotFound");
            return View(comingSoonDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id, IFormFile ifile, ComingSoon ic)
        {

            var comingSoonDetails = await _service.GetByIdAsync(id);
            if (comingSoonDetails == null) return View("NotFound");


            await _service.DeleteAsync(id);
            TempData["AlertMessage"] = "Item deleted successfully!";
            //var oldimagename = Path.Combine(_iwebhost.WebRootPath, "images", pizzaDetails.Image);
            //System.IO.File.Delete(oldimagename);
            return new RedirectResult(Url.Action("Index") + "#comingSoon");
        }

        //private bool MenusExists(int id)
        //{
        //    return _service.Menus.Any(e => e.Id == id);
        //}
    }
}

//private readonly ApplicationDbContext _context;

//public ComingSoonController(ApplicationDbContext context)
//{
//    _context = context;
//}

//// GET: ComingSoon
//public async Task<IActionResult> Index()
//{
//      return View(await _context.ComingSoon.ToListAsync());
//}

//// GET: ComingSoon/Details/5
//public async Task<IActionResult> Details(int? id)
//{
//    if (id == null || _context.ComingSoon == null)
//    {
//        return NotFound();
//    }

//    var comingSoon = await _context.ComingSoon
//        .FirstOrDefaultAsync(m => m.Id == id);
//    if (comingSoon == null)
//    {
//        return NotFound();
//    }

//    return View(comingSoon);
//}

// GET: ComingSoon/Create
//public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: ComingSoon/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,Image,Name,Description")] ComingSoon comingSoon)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(comingSoon);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(comingSoon);
//        }

//        // GET: ComingSoon/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.ComingSoon == null)
//            {
//                return NotFound();
//            }

//            var comingSoon = await _context.ComingSoon.FindAsync(id);
//            if (comingSoon == null)
//            {
//                return NotFound();
//            }
//            return View(comingSoon);
//        }

//        // POST: ComingSoon/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,Image,Name,Description")] ComingSoon comingSoon)
//        {
//            if (id != comingSoon.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(comingSoon);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!ComingSoonExists(comingSoon.Id))
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
//            return View(comingSoon);
//        }

//        // GET: ComingSoon/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.ComingSoon == null)
//            {
//                return NotFound();
//            }

//            var comingSoon = await _context.ComingSoon
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (comingSoon == null)
//            {
//                return NotFound();
//            }

//            return View(comingSoon);
//        }

//        // POST: ComingSoon/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.ComingSoon == null)
//            {
//                return Problem("Entity set 'ApplicationDbContext.ComingSoon'  is null.");
//            }
//            var comingSoon = await _context.ComingSoon.FindAsync(id);
//            if (comingSoon != null)
//            {
//                _context.ComingSoon.Remove(comingSoon);
//            }
            
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool ComingSoonExists(int id)
//        {
//          return _context.ComingSoon.Any(e => e.Id == id);
//        }
//    }
//}

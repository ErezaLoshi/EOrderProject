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
using Microsoft.Data.SqlClient;

namespace EOrderProject.Controllers
{
    public class MenusController : Controller
    {
        private readonly IMenusService _service;

        private readonly IWebHostEnvironment _iwebhost;

        public MenusController(IMenusService service, IWebHostEnvironment iwebhost)
        {
            _service = service;
            _iwebhost = iwebhost;
        }

        // GET: Menus
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
            var menus = from s in await _service.GetAllAsync()
                        select s;
            switch (sortOrder)
            {
                case "name_desc":
                    menus = menus.OrderByDescending(s => s.Name);
                    break;
                case "Price":
                    menus = menus.OrderBy(s => s.Price);
                    break;
                case "price_desc":
                    menus = menus.OrderByDescending(s => s.Price);
                    break;
                //case "Category":
                //    menus = menus.OrderByDescending(s => s.Category);
                //    break;
                //case "category_desc":
                //    menus = menus.OrderByDescending(s => s.Category);
                //    break;
                default:
                    menus = menus.OrderBy(s => s.Name);
                    break;
            }
            
            return View(menus);
        }
        public async Task<IActionResult> Fastfood()
        {
            var allMenus = await _service.GetAllAsync();
            return View(allMenus);
        }
        public async Task<IActionResult> Pasta()
        {
            var allMenus = await _service.GetAllAsync();
            return View(allMenus);
        }
        //public async Task<IActionResult> Salad()
        //{
        //    var allMenus = await _service.GetAllAsync();
        //    return View(allMenus);
        //}
        //public async Task<IActionResult> Drink()
        //{
        //    var allMenus = await _service.GetAllAsync();
        //    return View(allMenus);
        //}




        // GET: Menus/Details/5

        //public async Task<IActionResult> Details(int? id)
        //{
        

        //    if (id == null || _context.Menus == null)
        //    {
        //        return NotFound();
        //    }

        //    var menus = await _context.Menus
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (menus == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(menus);
        //}

        // GET: Menus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Menus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Image,Name,Description,Price,MenuCategory")] Menu menus, IFormFile ifile, Menu ic)
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
                menus.Image = imgname;
                await _service.AddAsync(menus);

                TempData["AlertMessage"] = "Item inserted successfully!";

                return new RedirectResult(Url.Action("Index") + "#menu");
            }
            else
            {
                TempData["ErrorMessage"] = "Please insert an image file!";

                return View(menus);
            }

        }




        //GET: menus/edit/$id
        public async Task<IActionResult> Edit(int id)
        {
            var menuDetails = await _service.GetByIdAsync(id);
            if (menuDetails == null) return View("NotFound");
            return View(menuDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Image,Name,Description,Price,MenuCategory")] Menu menu, IFormFile ifile, Menu ic)
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

            if (!ModelState.IsValid) return View(menu);

            if (id == menu.Id && error == 0)
            {
                menu.Image = newimgname;
                await _service.UpdateAsync(id, menu);
                TempData["AlertMessage"] = "Item edited successfully!";
                return new RedirectResult(Url.Action("Index") + "#menu");
            }
            else
            {
                TempData["ErrorMessage"] = "Please insert an image file!";
                return View(menu);
            }

        }


        //GET: pizzas/delete/$id
        public async Task<IActionResult> Delete(int id)
        {
            var menuDetails = await _service.GetByIdAsync(id);
            if (menuDetails == null) return View("NotFound");
            return View(menuDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id, IFormFile ifile, Menu ic)
        {

            var menuDetails = await _service.GetByIdAsync(id);
            if (menuDetails == null) return View("NotFound");


            await _service.DeleteAsync(id);
            TempData["AlertMessage"] = "Item deleted successfully!";
            //var oldimagename = Path.Combine(_iwebhost.WebRootPath, "images", pizzaDetails.Image);
            //System.IO.File.Delete(oldimagename);
            return new RedirectResult(Url.Action("Index") + "#menu");
        }

        //private bool MenusExists(int id)
        //{
        //    return _context.Menus.Any(e => e.Id == id);
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EOrderProject.Data;
using EOrderProject.Models;
using Microsoft.Data.SqlClient;
using EOrderProject.Data.Services;
using PagedList;

namespace EOrderProject.Controllers
{
    public class StaffsController : Controller
    {
        private readonly IStaffsService _service;
        private readonly IWebHostEnvironment _iwebhost;


        public StaffsController(IStaffsService service, IWebHostEnvironment iwebhost)
        {
            _service = service;
            _iwebhost = iwebhost;
        }

        // GET: Staffs
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {

            ViewBag.CurrentSort = sortOrder;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            ViewBag.NameSortParm= String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DescriptionSortParm = sortOrder == "Description" ? "description_desc" : "Description";



            var staffs = from s in await _service.GetAllAsync()
                         select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                staffs = staffs.Where(s => s.Name.Contains(searchString)
                                       || s.Description.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    staffs = staffs.OrderByDescending(s => s.Name);
                    break;
                case "Description":
                    staffs = staffs.OrderBy(s => s.Description);
                    break;
                case "description_desc":
                    staffs = staffs.OrderByDescending(s => s.Description);
                    break;
                default:
                    staffs = staffs.OrderBy(s => s.Name);
                    break;

            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(staffs.ToPagedList( pageNumber, pageSize));         
            //return View(staffs);
        }

        //// GET: Staffs/Details/5
        public async Task<IActionResult> Details(int id)
        {
            //if (id == null || _service.GetByIdAsync == null)
            //{
            //    return NotFound();
            //}

            var staffDetails = await _service.GetByIdAsync(id);
                //.FirstOrDefaultAsync(m => m.Id == id);
            if (staffDetails == null)return View ("NotFound");
            

            return View(staffDetails);
        }

        // GET: Staffs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Staffs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Image,Name,Description")] Staff staff, IFormFile ifile, Staff ic)
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
                staff.Image = imgname;
                await _service.AddAsync(staff);

                TempData["AlertMessage"] = "Item inserted successfully!";

                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["ErrorMessage"] = "Please insert an image file!";

                return View(staff);
            }

        }

        // GET: Staffs/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var menuDetails = await _service.GetByIdAsync(id);
            if (menuDetails == null) return View("NotFound");
            return View(menuDetails);
        }

        // POST: Staffs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Image,Name,Description")] Staff staff, IFormFile ifile, Staff ic)
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

            //if (!ModelState.IsValid) return View(staff);

            if (id == staff.Id && error == 0)
            {
                staff.Image = newimgname;
                await _service.UpdateAsync(id, staff);
                TempData["AlertMessage"] = "Item edited successfully!";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["ErrorMessage"] = "Please insert an image file!";
                return View(staff);
            }

        }

        // GET: Staffs/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var staffDetails = await _service.GetByIdAsync(id);
            if (staffDetails == null) return View("NotFound");
            return View(staffDetails);
        }

        // POST: Staffs/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id, IFormFile ifile, Staff ic)
        {

            var staffDetails = await _service.GetByIdAsync(id);
            if (staffDetails == null) return View("NotFound");


            await _service.DeleteAsync(id);
            TempData["AlertMessage"] = "Item deleted successfully!";
            //var oldimagename = Path.Combine(_iwebhost.WebRootPath, "images", pizzaDetails.Image);
            //System.IO.File.Delete(oldimagename);
            return RedirectToAction(nameof(Index));
        }
    }
}

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
using System.Net.NetworkInformation;

namespace EOrderProject.Controllers
{
    public class IssuessController : Controller
    {


        private readonly IIssueService _service;
        public IssuessController(IIssueService service)
        {
            _service = service;

        }
        public async Task<IActionResult> Index()
        {
            var allIssuess = await _service.GetAllAsync();
            return View(allIssuess);
        }




        //   GET: Menus/Details/5

        //public async Task<IActionResult> Details(int? id)
        //{

        //}




        //        GET: Menus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Menus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Image,Name,Description,Price,MenuCategory")] Issue issue)
        {
            if (!ModelState.IsValid)
            {
                return View(issue);
            }
            return RedirectToAction(nameof(Index));

        }

        //GET: menus/edit/$id
        public async Task<IActionResult> Edit(int id)
        {
            var issueDetails = await _service.GetByIdAsync(id);
            if (issueDetails == null) return View("NotFound");
            return View(issueDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Image,Name,Description,Price,MenuCategory")] Issue issue)
        {
            if (!ModelState.IsValid)
            {
                return View(issue);
            }
            await _service.UpdateAsync(id, issue);
            return RedirectToAction(nameof(Index));

        }


        // GET: menus/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var issue = await _service.GetByIdAsync(id);
            if (issue == null) return View("Not found");
            return View(issue);
        }

        // POST: menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var issue = await _service.GetByIdAsync(id);
            if (issue == null) return View("Not found");


            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}





















//        private readonly IIssueService _service;
//        public IssuessController(IIssueService service)
//        {
//            _service = service;

//        }
//        public async Task<IActionResult> Index()
//        {
//            var allIssuess = await _service.GetAllAsync();
//            return View(allIssuess);
//        }
//        //   GET: Menus/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Menus/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Issues,Suggestion")] Issue issue)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(issue);
//            }
//            return RedirectToAction(nameof(Index));

//        }

//        //GET: menus/edit/$id
//        public async Task<IActionResult> Edit(int id)
//        {
//            var IssueDetails = await _service.GetByIdAsync(id);
//            if (IssueDetails == null) return View("NotFound");
//            return View(IssueDetails);
//        }
        
//[HttpPost]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,Issues,Suggestion")] Issue issue)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(issue);
//            }
//            await _service.UpdateAsync(id, issue);
//            return RedirectToAction(nameof(Index));

//        }


//        // GET: menus/Delete/5
//        public async Task<IActionResult> Delete(int id)
//        {
//            var IssueDetails = await _service.GetByIdAsync(id);
//            if (IssueDetails == null) return View("Not found");
//            return View(IssueDetails);
//        }

//        // POST: menus/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {

//            var IssueDetails = await _service.GetByIdAsync(id);
//            if (IssueDetails == null) return View("Not found");

//            await _service.DeleteAsync(id);
//            TempData["AlertMessage"] = "Item deleted successfully!";
//            return RedirectToAction(nameof(Index));
//        }
//    }
//}

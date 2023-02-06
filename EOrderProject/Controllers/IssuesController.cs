
using EOrderProject.Data.Services;
using EOrderProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace eOrder.Controllers
{
    public class IssuesController : Controller
    {
        private readonly IIssuesService _service;
        public IssuesController(IIssuesService service)
        {
            _service = service;

        }
        public async Task<IActionResult> Index()
        {
            var allIssues = await _service.GetAllAsync();
            return View(allIssues);
        }
        //   GET: Menus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Menus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IssueDescription")] Issues Issues)
        {
            if (!ModelState.IsValid)
            {
                return View(Issues);
            }
            return RedirectToAction(nameof(Index));

        }

        //GET: menus/edit/$id
        public async Task<IActionResult> Edit(int id)
        {
            var IssueDetails = await _service.GetByIdAsync(id);
            if (IssueDetails == null) return View("NotFound");
            return View(IssueDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IssueDescription")] Issues Issues)
        {
            if (!ModelState.IsValid)
            {
                return View(Issues);
            }
            await _service.UpdateAsync(id, Issues);
            return RedirectToAction(nameof(Index));

        }


        // GET: menus/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var IssueDetails = await _service.GetByIdAsync(id);
            if (IssueDetails == null) return View("Not found");
            return View(IssueDetails);
        }

        // POST: menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var IssueDetails = await _service.GetByIdAsync(id);
            if (IssueDetails == null) return View("Not found");

            await _service.DeleteAsync(id);
            TempData["AlertMessage"] = "Item deleted successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
}


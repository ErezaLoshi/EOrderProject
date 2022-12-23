using EOrderProject.Data.Services;
using EOrderProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EOrderProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStaffsService _service;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IStaffsService service)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var allStaffs = await _service.GetAllAsync();
            return View(allStaffs);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
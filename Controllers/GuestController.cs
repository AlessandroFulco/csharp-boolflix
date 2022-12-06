using csharp_boolflix.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace csharp_boolflix.Controllers
{
    public class GuestController : Controller
    {
        private readonly ILogger<GuestController> _logger;

        public GuestController(ILogger<GuestController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["title"] = "Home";
            return View();
        }
       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
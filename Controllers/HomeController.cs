using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StockSphere_DN.Models;

namespace StockSphere.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: /Home/About (Maps to about.html)
        public IActionResult About()
        {
            return View();
        }

        // GET: /Home/Service (Maps to service.html)
        public IActionResult Services()
        {
            return View();
        }

        // GET: /Home/Blog (Maps to blog.html)
        public IActionResult Blog()
        {
            return View();
        }

        // GET: /Home/Team (Maps to team.html)
        public IActionResult Team()
        {
            return View();
        }

        // GET: /Home/Contact (Maps to contact.html)
        public IActionResult Contact()
        {
            return View();
        }

        // GET: /Home/NotFoundPage (Maps to 404.html)
        public IActionResult NotFoundPage()
        {
            return View();
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

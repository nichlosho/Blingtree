using BlingTree.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlingTree.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public ItemService itemService { get; }

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            itemService = new ItemService(env);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Flowers()
        {
            var items = itemService.GetAllData();
            return View(items);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
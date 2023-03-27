using BlingTree.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;

namespace BlingTree.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public ItemService itemService { get; }
        public List<Item> flowersList { get; set; }
        public int itemsPerPage = 15;
        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            itemService = new ItemService(env);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Flowers(int category, int page)
        {
            //add next prev paging
            if (category == 0)
            {
                flowersList = itemService.GetAllData().ToList();
            }
            else
            {
                flowersList = itemService.GetAllData().Where(x => x.Category == category).ToList();
            }
            return View(flowersList);
        }

        public IActionResult FlowerDetails(int id)
        {
            var flower = itemService.GetAllData().Where(x => x.ID == id).FirstOrDefault();
            return View(flower);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
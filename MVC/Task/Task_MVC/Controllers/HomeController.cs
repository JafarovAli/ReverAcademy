using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Task_MVC.Data;
using Task_MVC.Models;

namespace Task_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDBContext dBContext;

        public HomeController(ILogger<HomeController> logger, AppDBContext dBContext)
        {
            _logger = logger;
            this.dBContext = dBContext;
        }

        public async Task<IActionResult> Index()
        {
            var shop = await dBContext.Shop.ToListAsync();
            return View(shop);
        }

        public async Task<IActionResult> Shop()
        {
            return View();
        }
        public async Task<IActionResult> ShopSingle()
        {
            var shop = await dBContext.Shop.FirstOrDefaultAsync();
            return View(shop);
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
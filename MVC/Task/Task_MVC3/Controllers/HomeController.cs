using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Task_MVC3.Data;
using Task_MVC3.Models;
using Task_MVC3.ViewModels.CombinedViewModel;

namespace Task_MVC3.Controllers
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
            CombinedVM combinedVM = new CombinedVM();

            combinedVM.Products = await dBContext.Products.ToListAsync();
            await dBContext.SaveChangesAsync();

            return View(combinedVM);
        }
        public async Task<IActionResult> Shop()
        {
            CombinedVM combinedVM = new CombinedVM();

            combinedVM.Products = await dBContext.Products.ToListAsync();

            return View(combinedVM);
        }

        public async Task<IActionResult> ContactUs()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ContactUs(CombinedVM contact)
        {
            ContactUs contactUs = new ContactUs()
            {
                Name = contact.ContactUsVM.Name,
                Email = contact.ContactUsVM.Email,
                Phone = contact.ContactUsVM.Phone,
                Message = contact.ContactUsVM.Message
            };
            await dBContext.ContactUs.AddAsync(contactUs);
            await dBContext.SaveChangesAsync();
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
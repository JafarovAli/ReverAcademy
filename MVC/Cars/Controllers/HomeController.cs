using Cars.Data;
using Cars.Models;
using Cars.ViewModels.CombinedViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Cars.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDBContext dBContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDBContext dBContext)
        {
            _logger = logger;
            this.dBContext = dBContext;
        }

        public async Task<IActionResult> Index()
        {
            CombinedVM combinedVM = new CombinedVM();
            
            combinedVM.Cars = await dBContext.Cars.ToListAsync();
            return View(combinedVM);
        }
        
        public async Task<IActionResult> ContactUs(CombinedVM contact)
        {
            ContactUs contactUs = new ContactUs()
            {
                Email = contact.ContactUsVM.Email
            };
            await dBContext.ContactUs.AddAsync(contactUs);
            await dBContext.SaveChangesAsync();
            return RedirectToAction("Index");
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
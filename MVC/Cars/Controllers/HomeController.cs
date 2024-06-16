using Cars.Data;
using Cars.Models;
using Cars.ViewModels.ContacUs;
using Microsoft.AspNetCore.Mvc;
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
			//List<Car> car = new List<Car>();
            //car = await dBContext.Cars.ToListAsync();
            return View();
        }
        
        public async Task<IActionResult> ContactUs(ContactUsVM contact)
        {
			ContactUs contactUs = new ContactUs()
            {
                Email = contact.Email,
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
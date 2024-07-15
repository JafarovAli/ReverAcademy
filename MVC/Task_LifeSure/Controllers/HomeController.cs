using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Task_LifeSure.Data;
using Task_LifeSure.Models;
using Task_LifeSure.ViewModel.CombinedViewModel;

namespace Task_LifeSure.Controllers
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

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> OurTeam()
        {
            CombinedVM combinedVM = new CombinedVM();
            combinedVM.OurTeams =await dBContext.OurTeams.ToListAsync();
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
                Project = contact.ContactUsVM.Project,
                Subject = contact.ContactUsVM.Subject,
                Message = contact.ContactUsVM.Message
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
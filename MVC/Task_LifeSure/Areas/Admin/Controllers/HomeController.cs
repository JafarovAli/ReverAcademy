using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_LifeSure.Data;
using Task_LifeSure.ViewModel.CombinedViewModel;

namespace Task_LifeSure.Areas.Admin.Controllers
{
    [Area("admin")]
    public class HomeController : Controller
    {
        private readonly AppDBContext dBContext;

        public HomeController(AppDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Contact()
        {
            var contactUs = await dBContext.ContactUs.ToListAsync();
            return View(contactUs);
        }
    }
}

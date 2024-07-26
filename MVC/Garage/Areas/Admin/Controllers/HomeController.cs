using Garage.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Garage.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
	{
        private readonly ApplicationDBContext dBContext;

        public HomeController(ApplicationDBContext dBContext)
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

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Task_MVC3.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("admin")]
        [Authorize]
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}

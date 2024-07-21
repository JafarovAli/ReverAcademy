using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using Task_MVC3.Models;
using Task_MVC3.ViewModels;

namespace Task_MVC3.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            AppUser appUser = new AppUser()
            {
                Name = registerVM.Name,
                Email = registerVM.Email,
                Surname = registerVM.Surname,
                UserName = registerVM.UserName
            };
            await userManager.CreateAsync(appUser,registerVM.Password);
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            var user = await userManager.FindByNameAsync(loginVM.UserName);
            if (user == null) 
            {
                return View(loginVM);
            }
            var result = await signInManager.PasswordSignInAsync(user, loginVM.Password,true,false);
            if (!result.Succeeded)
            {
                return View(loginVM);
            }
            return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}

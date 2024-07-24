using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using Task_MVC3.Data;
using Task_MVC3.Models;
using Task_MVC3.ViewModels.CombinedViewModel;
using Task_MVC3.ViewModels.SettingsVM;

namespace Task_MVC3.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize]
    [Authorize(Roles = "Admin")]
    public class SettingsController : Controller
    {
        private readonly AppDBContext dBContext;

        public SettingsController(AppDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<IActionResult> Index()
        {
            var setting = await dBContext.Settings.FirstOrDefaultAsync();
            return View(setting);
        }
        public async Task<IActionResult> Edit()
        {
            var setting = await dBContext.Settings.FirstOrDefaultAsync();
            CombinedVM combinedVM = new CombinedVM();
            if (setting is not null)
            {
                combinedVM.SettingVM = new SettingVM()
                {
                    AboutUs = setting.AboutUs,
                    Phone = setting.Phone,
                    Location = setting.Location,
                    EmailAddress = setting.EmailAddress
                };
            }
            return View(combinedVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SettingVM settingVM)
        {
            var existingSetting = await dBContext.Settings.FirstOrDefaultAsync();
            if (existingSetting == null)
            {
                existingSetting = new Settings()
                {
                    AboutUs = settingVM.AboutUs,
                    Phone = settingVM.Phone,
                    Location = settingVM.Location,
                    EmailAddress = settingVM.EmailAddress
                };
                await dBContext.Settings.AddAsync(existingSetting);
            }
            else
            {
                existingSetting.AboutUs = settingVM.AboutUs;
                existingSetting.Phone = settingVM.Phone;
                existingSetting.Location = settingVM.Location;
                existingSetting.EmailAddress = settingVM.EmailAddress;
            }
            await dBContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

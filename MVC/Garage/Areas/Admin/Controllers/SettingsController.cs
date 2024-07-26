using Garage.Data;
using Garage.Models;
using Garage.ViewModel.CombinedViewModel;
using Garage.ViewModel.SettingViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Garage.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	[Authorize(Roles ="Admin")]
	public class SettingsController : Controller
	{
		private readonly ApplicationDBContext dBContext;

		public SettingsController(ApplicationDBContext dBContext)
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
					PhoneNumber = setting.PhoneNumber,
					FacebookUrl = setting.FacebookUrl,
					TwitterUrl = setting.TwitterUrl,
					GoogleSiteUrl = setting.GoogleSiteUrl,
					PinterestUrl = setting.PinterestUrl,
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
					PhoneNumber = settingVM.PhoneNumber,
					FacebookUrl = settingVM.FacebookUrl,
					TwitterUrl = settingVM.TwitterUrl,
					GoogleSiteUrl = settingVM.GoogleSiteUrl,
					PinterestUrl = settingVM.PinterestUrl,
				};
				await dBContext.Settings.AddAsync(existingSetting);
			}
			else
			{
				existingSetting.PhoneNumber = settingVM.PhoneNumber;
				existingSetting.FacebookUrl = settingVM.FacebookUrl;
				existingSetting.TwitterUrl = settingVM.TwitterUrl;
				existingSetting.GoogleSiteUrl = settingVM.GoogleSiteUrl;
				existingSetting.PinterestUrl = settingVM.PinterestUrl;
			}
			await dBContext.SaveChangesAsync();
			return RedirectToAction("Index");
		}
	}
}

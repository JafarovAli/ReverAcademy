using Garage.Data;
using Garage.Helpers;
using Garage.Models;
using Garage.ViewModel;
using Garage.ViewModel.CombinedViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Garage.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize]
    [Authorize(Roles = "Admin")]
    public class CarController : Controller
	{
		private readonly ApplicationDBContext dBContext;
		private readonly IWebHostEnvironment env;

        public CarController(ApplicationDBContext dBContext, IWebHostEnvironment env)
        {
            this.dBContext = dBContext;
            this.env = env;
        }

        public async Task<IActionResult> Index()
		{
			CombinedVM combinedVM = new CombinedVM();
			combinedVM.Cars = await dBContext.Cars.ToListAsync();
			return View(combinedVM);
		}

		public async Task<IActionResult> Add()
		{
			return View();
		}

		[HttpPost]
        public async Task<IActionResult> Add(CarVM carVM)
        {
			Car car = new Car()
			{
				Name = carVM.Name,
				Description = carVM.Description,
				Price = carVM.Price,
				Image = carVM.Image.Upload(env.WebRootPath, "/Images/url/")
			};
			await dBContext.Cars.AddAsync(car);
			await dBContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

		public async Task<IActionResult> Delete(int id)
		{
			Car car = await dBContext.Cars.FirstOrDefaultAsync(x=>x.Id == id);
			dBContext.Cars.Remove(car);
			await dBContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            Car car = await dBContext.Cars.FirstOrDefaultAsync(x => x.Id == id);

            return View(car);
        }

		[HttpPost]
		public async Task<IActionResult> Update(Car car)
		{
			dBContext.Update(car);
			await dBContext.SaveChangesAsync();
			return RedirectToAction("Index");
		}
    }
}

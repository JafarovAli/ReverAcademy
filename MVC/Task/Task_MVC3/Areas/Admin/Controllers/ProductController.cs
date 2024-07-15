using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Task_MVC3.Data;
using Task_MVC3.Models;
using Task_MVC3.ViewModels.CombinedViewModel;

namespace Task_MVC3.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly AppDBContext dBContext;

        public ProductController(AppDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<IActionResult> Index()
        {
            CombinedVM combinedVM = new CombinedVM();

            combinedVM.Products = await dBContext.Products.ToListAsync();
            return View(combinedVM);
        }

        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Products products)
        {
            await dBContext.Products.AddAsync(products);
            await dBContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            Products products = await dBContext.Products.FirstOrDefaultAsync(x=>x.Id==id);
            dBContext.Products.Remove(products);
            await dBContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            Products products = await dBContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            return View(products);
        }
        
        [HttpPost]
        public async Task<IActionResult> Update(Products products)
        {
            dBContext.Update(products);
            await dBContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

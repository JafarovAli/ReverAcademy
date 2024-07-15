using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_LifeSure.Data;
using Task_LifeSure.Helpers;
using Task_LifeSure.Models;
using Task_LifeSure.ViewModel;
using Task_LifeSure.ViewModel.CombinedViewModel;

namespace Task_LifeSure.Areas.Admin.Controllers
{
    [Area("admin")]
    public class TeamController : Controller
    {
        private readonly AppDBContext dBContext;
        private readonly IWebHostEnvironment env;
        public TeamController(AppDBContext dBContext, IWebHostEnvironment env)
        {
            this.dBContext = dBContext;
            this.env = env;
        }

        public async Task<IActionResult> Index()
        {
            CombinedVM vm = new CombinedVM();
            vm.OurTeams = await dBContext.OurTeams.ToListAsync();
            return View(vm);
        }

        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(OurTeamVM teamVM)
        {
            OurTeam team = new OurTeam()
            {
                Name = teamVM.Name,
                Description = teamVM.Description,
                Image = teamVM.Image.Upload(env.WebRootPath,"/Image/")
            };
            await dBContext.OurTeams.AddAsync(team);
            await dBContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            OurTeam ourTeam = await dBContext.OurTeams.FirstOrDefaultAsync(x=>x.Id== id);
            dBContext.OurTeams.Remove(ourTeam);
            await dBContext.SaveChangesAsync(); 
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            OurTeam ourTeam = await dBContext.OurTeams.FirstOrDefaultAsync(x=>x.Id== id);
            return View(ourTeam);
        }

        [HttpPost]
        public async Task<IActionResult> Update(OurTeam team)
        {
            dBContext.OurTeams.Update(team);
            await dBContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NTeirApp.Business.DTOs.CarDTO;
using NTeirApp.Business.Services.Interfaces;

namespace NTeirApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService carService;

        public CarController(ICarService carService)
        {
            this.carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await carService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await carService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateCarDTO createCarDTO)
        {
            await carService.CreateAsync(createCarDTO);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateCarDTO updateCarDTO)
        {
            await carService.UpdateAsync(updateCarDTO);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await carService.DeleteAsync(id);
            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NTierApp.Business.DTOs.ProductDTO;
using NTierApp.Business.Services.Interfaces;

namespace NTierApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await productService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await productService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateProductDTO createProductDTO)
        {
            await productService.CreateAsync(createProductDTO);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteAsync(int id)
        {
            await productService.DeleteAsync(id);
            return StatusCode(StatusCodes.Status202Accepted);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateProductDTO updateProductDTO)
        {
            await productService.UpdateAsync(updateProductDTO);
            return StatusCode(StatusCodes.Status201Created);
        }

    }
}

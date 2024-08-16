using NTierApp.Business.DTOs.ProductDTO;
using NTierApp.Business.Services.Interfaces;
using NTierApp.Core;
using NTierApp.Dal.Repositories.Interfaces;

namespace NTierApp.Business.Services.Abstractions
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task CreateAsync(CreateProductDTO createProductDTO)
        {
            Product product = new Product()
            {
                Title = createProductDTO.Title,
                Description = createProductDTO.Description
            };
             await productRepository.CreateAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            await productRepository.DeleteAsync(id);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await productRepository.GetAllAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await productRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(UpdateProductDTO updateProductDTO)
        {
            Product product = new Product()
            {
                Title = updateProductDTO.Title,
                Description = updateProductDTO.Description,
                Id = updateProductDTO.Id
            };
            await productRepository.UpdateAsync(product);
        }
    }
}

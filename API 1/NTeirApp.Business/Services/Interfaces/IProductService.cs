using NTierApp.Business.DTOs.ProductDTO;
using NTierApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApp.Business.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task CreateAsync(CreateProductDTO createProductDTO);
        Task UpdateAsync(UpdateProductDTO updateProductDTO);
        Task DeleteAsync(int id);
    }
}

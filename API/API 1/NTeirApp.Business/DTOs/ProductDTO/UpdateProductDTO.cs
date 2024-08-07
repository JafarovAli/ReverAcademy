using NTierApp.Business.DTOs.BaseEntityDTO;

namespace NTierApp.Business.DTOs.ProductDTO
{
    public class UpdateProductDTO : BaseDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

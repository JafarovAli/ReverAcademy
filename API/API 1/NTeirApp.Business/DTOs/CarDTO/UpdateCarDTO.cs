using NTierApp.Business.DTOs.BaseEntityDTO;

namespace NTeirApp.Business.DTOs.CarDTO
{
    public class UpdateCarDTO : BaseDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
}

using Garage.Models.Commons;

namespace Garage.Models
{
    public class Car:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
    }
}

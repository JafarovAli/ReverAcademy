using Task_MVC3.Models.Commons;

namespace Task_MVC3.Models
{
    public class Products:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Image {  get; set; }
        public bool IsNew { get; set; }
    }
}

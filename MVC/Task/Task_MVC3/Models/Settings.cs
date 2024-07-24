using Task_MVC3.Models.Commons;

namespace Task_MVC3.Models
{
    public class Settings:BaseEntity
    {
        public string AboutUs { get; set; }
        public string Phone { get; set;}
        public string EmailAddress { get; set;}
        public string Location { get; set;}
    }
}

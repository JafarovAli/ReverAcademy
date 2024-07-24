using Task_MVC3.Models.Commons;

namespace Task_MVC3.Models
{
    public class ContactUs:BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
    }
}

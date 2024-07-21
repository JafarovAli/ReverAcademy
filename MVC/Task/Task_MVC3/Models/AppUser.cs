using Microsoft.AspNetCore.Identity;

namespace Task_MVC3.Models
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}

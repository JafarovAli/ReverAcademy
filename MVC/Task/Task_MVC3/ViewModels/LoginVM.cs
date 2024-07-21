using System.ComponentModel.DataAnnotations;

namespace Task_MVC3.ViewModels
{
    public class LoginVM
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

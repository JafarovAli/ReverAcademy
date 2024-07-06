using Task_MVC3.Models;
using Task_MVC3.ViewModels.ContactUs;

namespace Task_MVC3.ViewModels.CombinedViewModel
{
    public class CombinedVM
    {
        public List<Products> Products { get; set; }
        public ContactUsVM ContactUsVM {  get; set; } 
    }
}

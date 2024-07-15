using Task_LifeSure.Models;
using Task_LifeSure.ViewModel.ContactUs;

namespace Task_LifeSure.ViewModel.CombinedViewModel
{
    public class CombinedVM
    {
        public List<OurTeam> OurTeams { get; set; }
        public ContactUsVM ContactUsVM { get; set; }
    }
}

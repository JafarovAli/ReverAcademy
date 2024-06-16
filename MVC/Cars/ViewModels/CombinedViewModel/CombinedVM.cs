using Cars.Models;
using Cars.ViewModels.ContacUs;

namespace Cars.ViewModels.CombinedViewModel
{
	public class CombinedVM
	{
		public List<Car> Cars { get; set; }
		public ContactUsVM ContactUsVM { get; set; }
	}
}

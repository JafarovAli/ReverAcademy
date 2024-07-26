using Garage.Models;
using Garage.ViewModel.ContactUs;
using Garage.ViewModel.SettingViewModel;

namespace Garage.ViewModel.CombinedViewModel
{
	public class CombinedVM
	{
		public List<Car> Cars { get; set; }
		public ContactUsVM ContactUsVM { get; set; }
		public SettingVM SettingVM { get; set; }
	}
}

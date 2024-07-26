using Garage.Models.Commons;

namespace Garage.Models
{
	public class Settings:BaseEntity
	{
		public string PhoneNumber { get; set; }
		public string FacebookUrl { get; set; }
		public string TwitterUrl { get; set; }
		public string GoogleSiteUrl { get; set;}
		public string PinterestUrl { get; set; }
	}
}

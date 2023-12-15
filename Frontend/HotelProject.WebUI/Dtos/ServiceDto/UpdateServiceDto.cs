using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
	public class UpdateServiceDto
	{
		public string ServiceId { get; set; }
		[Required(ErrorMessage = "Service Ikon Link required")]
		public string ServiceIcon { get; set; }
		[Required(ErrorMessage = "Service title required")]
		[MaxLength(40, ErrorMessage = "Title's max length can only be 40 characters")]
		public string Title { get; set; }

		[Required(ErrorMessage = "Service desc required")]
		[MaxLength(140, ErrorMessage = "Title's max length can only be 140 characters")]
		public string Description { get; set; }
	}
}

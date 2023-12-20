

using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.BookingDto
{
	public class CreateBookingDto
	{
		/*[Required(ErrorMessage = "This field is required")]*/
		public string Name { get; set; }
		/*[Required(ErrorMessage = "This field is required")]*/
		public string Mail { get; set; }
		/*[Required(ErrorMessage = "This field is required")]*/
		public DateTime CheckIn { get; set; }
		/*[Required(ErrorMessage = "This field is required")]*/
		public DateTime CheckOut { get; set; }
		/*[Required(ErrorMessage = "This field is required")]*/
		public string AdultCount { get; set; }
		/*[Required(ErrorMessage = "This field is required")]*/
		public string ChildCount { get; set; }
		/*[Required(ErrorMessage = "This field is required")]*/
		public string RoomCount { get; set; }
		/*[Required(ErrorMessage = "This field is required")]*/
		public string SpecialRequest { get; set; }
		/*[Required(ErrorMessage = "This field is required")]*/
		public string Description { get; set; }
		/*[Required(ErrorMessage = "This field is required")]*/
		public string Status { get; set; }

	}
}

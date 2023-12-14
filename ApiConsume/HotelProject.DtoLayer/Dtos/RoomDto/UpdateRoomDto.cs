using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.RoomDto
{
	public class UpdateRoomDto
	{
		// güncellerken Id gelmesi şart
		
		public int RoomID { get; set; }
		[Required(ErrorMessage = "Room number needed")]
		public string RoomNumber { get; set; }
		[Required(ErrorMessage = "Room image needed")]
		public string RoomCoverImage { get; set; }
		[Required(ErrorMessage = "Price needed")]
		public int Price { get; set; }
		[Required(ErrorMessage = "Title of room needed")]
		[StringLength(30,ErrorMessage= "Max 30 character allowed")]
		public string Title { get; set; }
		[Required(ErrorMessage = "Bath count needed")]
		public string BathCount { get; set; }
		[Required(ErrorMessage = "Bed count needed")]
		public string BedCount { get; set; }
		public string Wifi { get; set; }
		[Required(ErrorMessage = "Room description needed")]
		public string Description { get; set; }
	}
}

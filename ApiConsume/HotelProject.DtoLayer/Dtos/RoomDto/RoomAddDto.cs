using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.RoomDto
{
	public class RoomAddDto
	{
		// vermezse null olarak kaydeder onda sorun yok
		[Required(ErrorMessage = "Room number needed")]
		public string RoomNumber { get; set; }
		public string RoomCoverImage { get; set; }
		[Required(ErrorMessage = "Price needed")]
		public int Price { get; set; }
		[Required(ErrorMessage = "Title of room needed")]
		public string Title { get; set; }
		[Required(ErrorMessage = "Bath count needed")]
		public string BathCount { get; set; }
		[Required(ErrorMessage = "Bed count needed")]
		public string BedCount { get; set; }
		public string Wifi { get; set; }
		public string Description { get; set; }
	}
}

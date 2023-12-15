using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
	public class CreateServiceDto
	{
		// id gerek yok kendi olusturur
		[Required(ErrorMessage = "Service Ikon Link required")]
		public string ServiceIcon { get; set; }
		[Required(ErrorMessage = "Service title required")]
		[MaxLength(40 , ErrorMessage = "Title's max length can only be 40 characters")]
		public string Title { get; set; }
		// şuan olmasada olur
		private string _description;

		public string Description
		{	//bos gelirse buna esitle // Null deger istemiyor -- cok ugrastim
			get => _description ?? "Default";
			set => _description = value;
		}
	}
}

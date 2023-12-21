using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using HotelProject.WebUI.Dtos.BookingDto;

namespace HotelProject.WebUI.Controllers
{
	public class BookingAdminController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public BookingAdminController(IHttpClientFactory client)
		{
			_httpClientFactory = client;
		}
		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("http://localhost:5051/api/Booking");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
				return View(values);
			}
			return View();
		}


		// burasi id ile de çağırılacak ama sonra !
		public async Task<IActionResult> ApprovedReservation(ApprovedBookingDto dto)
		{	// diğer bilgiler null kalamaz gönderme işlemi kesin başarısız olur
			dto.Status = "approved";
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(dto);
			StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
			var responseMessage = await client.PostAsync("http://localhost:5051/api/Booking/UpdateBooking", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index");
		}
	}
}

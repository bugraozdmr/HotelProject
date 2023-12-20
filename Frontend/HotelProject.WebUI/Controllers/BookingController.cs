using System.Text;
using HotelProject.WebUI.Dtos.BookingDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Controllers
{
	public class BookingController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public BookingController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public PartialViewResult AddBooking()
		{
			return PartialView();
		}

		[HttpPost]
		public async Task<IActionResult> AddBooking(CreateBookingDto bookingDto)
		{
			bookingDto.Status = "Waiting for apply";
			bookingDto.Description = "Please examine the request";
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(bookingDto);
			StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
			await client.PostAsync("http://localhost:5051/api/Booking", content);
			
			return RedirectToAction("Index","Default");
		}
	}
}

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models.Booking;

namespace RapidApiConsume.Controllers
{
	public class BookingController : Controller
	{
		public async Task<IActionResult> Index()
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://booking-com.p.rapidapi.com/v2/hotels/search?units=metric&locale=en-gb&checkin_date=2023-12-23&dest_type=city&order_by=popularity&filter_by_currency=USD&adults_number=2&room_number=1&dest_id=-1456928&checkout_date=2023-12-25&include_adjacency=true&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&page_number=0&children_ages=5%2C0&children_number=2"),
				Headers =
				{
					{ "X-RapidAPI-Key", "cc43fab76emsh21b71a713c00a15p1188cbjsn49cedfeefe88" },
					{ "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
				},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
			
				// list gondermeme gerek yok zaten çektiği veri bir arraye sahip
				var values = JsonConvert.DeserializeObject<BookingApiViewModel>(body);
				// toList'e çevirmezsen model sorun yaşar
				return View(values.results.ToList());
			}
		}
	}
}

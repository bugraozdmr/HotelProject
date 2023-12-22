using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models.Booking;

namespace RapidApiConsume.Controllers
{
	public class SearchLocationController : Controller
	{
		public async Task<IActionResult> Index(string cityName)
		{
			if (!string.IsNullOrEmpty(cityName))
			{
				List<SearchLocationIdViewModel> search = new List<SearchLocationIdViewModel>();

				var client = new HttpClient();
				var request = new HttpRequestMessage
				{
					Method = HttpMethod.Get,
					RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={cityName}&locale=en-gb"),
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

					search = JsonConvert.DeserializeObject<List<SearchLocationIdViewModel>>(body);
					// sadece 1 tane almak istesek
					return View(search.Take(1).ToList());
				}
			}
			//******************
			else
			{
				List<SearchLocationIdViewModel> search = new List<SearchLocationIdViewModel>();

				var client = new HttpClient();
				var request = new HttpRequestMessage
				{
					Method = HttpMethod.Get,
					RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/locations?name=Berlin&locale=en-gb"),
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

					search = JsonConvert.DeserializeObject<List<SearchLocationIdViewModel>>(body);
					// sadece 1 tane almak istesek
					return View(search.Take(1).ToList());
				}
			}
		}
	}
}

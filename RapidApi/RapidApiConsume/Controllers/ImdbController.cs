using Microsoft.AspNetCore.Mvc;

namespace RapidApiConsume.Controllers
{
	public class ImdbController : Controller
	{
		public async Task<IActionResult> Index()
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
				Headers =
				{
					{ "X-RapidAPI-Key", "cc43fab76emsh21b71a713c00a15p1188cbjsn49cedfeefe88" },
					{ "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
				},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
			}

			return View();
		}
	}
}

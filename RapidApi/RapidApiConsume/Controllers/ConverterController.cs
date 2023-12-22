using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models.Converter;

namespace RapidApiConsume.Controllers
{
	public class ConverterController : Controller
	{
		public async Task<IActionResult> Index()
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://apidojo-booking-v1.p.rapidapi.com/currency/get-exchange-rates?base_currency=USD&languagecode=en-us"),
				Headers =
				{
					{ "X-RapidAPI-Key", "cc43fab76emsh21b71a713c00a15p1188cbjsn49cedfeefe88" },
					{ "X-RapidAPI-Host", "apidojo-booking-v1.p.rapidapi.com" },
				},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();

				var viewModel = JsonConvert.DeserializeObject<ConverterViewModel>(body);
				return View(viewModel.exchange_rates.ToList());
			}
		}
	}
}

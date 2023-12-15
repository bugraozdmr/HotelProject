using HotelProject.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Controllers
{
	public class ServiceController : Controller
	{
		private readonly IHttpClientFactory _client;

		public ServiceController(IHttpClientFactory httpClientFactory)
		{
			_client = httpClientFactory;
		}
		public async Task<IActionResult> Index()
		{
			var client = _client.CreateClient();
			var responseMessage = await client.GetAsync("http://localhost:5051/api/Service");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
				return View(values);		// içi boş giderse model yok diye null exception döner
			}
			return View();
		}
	}
}

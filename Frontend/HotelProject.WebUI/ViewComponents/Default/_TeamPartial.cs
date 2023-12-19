using HotelProject.WebUI.Dtos.StaffDto;
using HotelProject.WebUI.Dtos.TestimonialDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Default
{
	public class _TeamPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _TeamPartial(IHttpClientFactory client)
		{
			_httpClientFactory = client;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("http://localhost:5051/api/Staff");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsondata = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultStaffDto>>(jsondata);
				return View(values);
			}

			return View();
		}
	}
}

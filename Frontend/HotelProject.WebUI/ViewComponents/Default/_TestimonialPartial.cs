using HotelProject.WebUI.Dtos.RoomDto;
using HotelProject.WebUI.Dtos.TestimonialDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Default
{
	public class _TestimonialPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _TestimonialPartial(IHttpClientFactory client)
		{
			_httpClientFactory = client;
		}

		// InvokeAsync olmazsa çalışmaz !!!
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("http://localhost:5051/api/Testimonial");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsondata = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsondata);
				return View(values);
			}

			return View();
		}
	}
}

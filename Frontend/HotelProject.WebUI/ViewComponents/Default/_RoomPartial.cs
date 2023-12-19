using HotelProject.WebUI.Dtos.RoomDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class _RoomPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _RoomPartial(IHttpClientFactory client)
        {
	        _httpClientFactory = client;
        }

		// invoke olmak zorunda yoksa patlıyor
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("http://localhost:5051/api/Room");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsondata = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultRoomDto>>(jsondata);
				return View(values);
			}

			return View();
        }
    }
}

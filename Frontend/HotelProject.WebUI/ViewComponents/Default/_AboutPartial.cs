using HotelProject.WebUI.Dtos.AboutDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class _AboutPartial : ViewComponent
    {
        private readonly IHttpClientFactory _client;

        public _AboutPartial(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory;
        }

        // eğer async işlem varsa isim değişmek zorunda InvokeAsync
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _client.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5051/api/About");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);        // içi boş giderse model yok diye null exception döner
            }
            return View();
        }
    }
}

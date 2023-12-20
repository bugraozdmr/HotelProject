using System.Text;
using HotelProject.WebUI.Dtos.SubscribeDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory client)
        {
	        _httpClientFactory = client;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult _SubscribePartial()
        {
			return PartialView();
        }

        // task yöntemi değişti
        [HttpPost]
        public async Task<IActionResult> _SubscribePartial(CreateSubscribeDto subscribeDto)
		{   // CreateSubscribeDto bir tek maili tuttugu icin ayrı bir dto yazmaya gerek yoktu direkt aldığını maile atadı -- ama name="mail" yaptık yine input içinde
			// veiws altın default altında oluşmuş view yeri
			var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(subscribeDto);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("http://localhost:5051/api/Subscribe", content);
            if (responseMessage.IsSuccessStatusCode)
            {
	            return RedirectToAction("Index","Default");
            }
            return RedirectToAction("Index", "Default");

            // asp-controller / asp-action ekle yoksa bulamaz bu metodu form
		}
	}
}

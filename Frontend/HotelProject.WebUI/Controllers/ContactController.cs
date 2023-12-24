using System.Text;
using HotelProject.WebUI.Dtos.ContactDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Controllers
{
    public class ContactController : Controller
    {
        public readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult sendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> sendMessage(CreateMessageDto createMessageDto)
        {
            createMessageDto.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createMessageDto);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            await client.PostAsync("http://localhost:5051/api/Contact", content);
            return RedirectToAction("Index", "Default");
        }
    }
}

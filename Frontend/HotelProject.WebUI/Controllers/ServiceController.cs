using HotelProject.WebUI.Dtos.ServiceDto;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
	public class ServiceController : Controller
	{
		private readonly IHttpClientFactory _client;

		public ServiceController(IHttpClientFactory httpClientFactory)
		{
			_client = httpClientFactory;
		}
		[HttpGet]
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

		[HttpGet]
		public IActionResult addService()
		{
			// ayni isimde olustur view dosylarını
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> addService(CreateServiceDto createServiceDto)
		{
			if (!ModelState.IsValid)
			{
				// önce burası çalışacak model gidince eğer model geçersizse aşşağıya gidecektir -- api hatası atar aşşağısı ancak.
				return View();
			}
			var client = _client.CreateClient();
			// string lazım -- string json çevirilip gönderilir
			var jsondata = JsonConvert.SerializeObject(createServiceDto);
			StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("http://localhost:5051/api/Service", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		// burda route ya da httpdelete gereksiz sadece sayfa yonlendiricisi bu get default'udur -- default olanı alır -- await isleminde delete tanımlı
		public async Task<IActionResult> DeleteService(int id)
		{
			var client = _client.CreateClient();
			var responseMessage = await client.DeleteAsync($"http://localhost:5051/api/Service/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("index");
			}
			// hata dönmesin diye geçici yazıldı -- boş bırakamazdım
			return View("Index");
		}

		[HttpGet]
		public async Task<IActionResult> UpdateService(int id)
		{
			var client = _client.CreateClient();     // getbyid çalışır -- api'dan o işlemi istiyoruz
			var responseMessage = await client.GetAsync($"http://localhost:5051/api/Service/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsondata = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateServiceDto>(jsondata);

				// model gidecekti ve biz o modeli doldurup yolladık
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UpdateService(UpdateServiceDto model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			
			var client = _client.CreateClient();
			var jsonData = JsonConvert.SerializeObject(model);
			StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
			var responseMessage = await client.PutAsync("http://localhost:5051/api/Service", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View(model);
		}


		public async Task<IActionResult> showDetails(int id)
		{
			var client = _client.CreateClient();
			var responseMessage =await client.GetAsync($"http://localhost:5051/api/Service/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<ResultServiceDto>(jsonData);
				return View(value);
			}
			return View();
		}
	}
}

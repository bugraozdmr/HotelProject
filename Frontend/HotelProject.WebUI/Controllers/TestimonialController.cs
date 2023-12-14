using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using HotelProject.WebUI.Models.Testimonial;

namespace HotelProject.WebUI.Controllers
{
	public class TestimonialController : Controller
	{
		
        private readonly IHttpClientFactory _httpClientFactory;

		public TestimonialController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		// artık görevi var
		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("http://localhost:5051/api/Testimonial");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				// verilen objeye göreye yani liste ve içindekilere göre gelen jsondata dönüştürülecek
				var values = JsonConvert.DeserializeObject<List<TestimonialViewModel>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpGet]
		public IActionResult addTestimonial()
		{
			// ayni isimde olustur view dosylarını
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> addTestimonial(TestimonialViewModel model)
		{
			var client = _httpClientFactory.CreateClient();
			// bu sefer gelen değeri class türüne çevirecek
			var jsondata = JsonConvert.SerializeObject(model);
			StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("http://localhost:5051/api/Testimonial", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> DeleteTestimonial(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"http://localhost:5051/api/Testimonial/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("index");
			}
			// hata dönmesin diye geçici yazıldı -- boş bırakamazdım
			return View("Index");
		}

		[HttpGet]
		public async Task<IActionResult> UpdateTestimonial(int id)
		{
			var client = _httpClientFactory.CreateClient();     // getbyid gibi çalışır
			var responseMessage = await client.GetAsync($"http://localhost:5051/api/Testimonial/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsondata = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<TestimonialViewModel>(jsondata);

				// model gidecekti ve biz o modeli doldurup yolladık
				return View(values);
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UpdateTestimonial(TestimonialViewModel model)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(model);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("http://localhost:5051/api/Testimonial", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				// return olmazsa assa iner
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> ShowDetails(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"http://localhost:5051/api/Testimonial/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				Console.WriteLine(jsonData);
				var value = JsonConvert.DeserializeObject<ShowDetailsViewModel>(jsonData);

				return View(value);
			}
			return View();
		}
	}
}
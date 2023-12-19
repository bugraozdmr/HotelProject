using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
	public class RoomController : Controller
	{
		public IActionResult Index()
		{
			// admin için gerekli -- 
			return View();
		}
	}
}

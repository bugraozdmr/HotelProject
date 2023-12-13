using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class StaffController : Controller
    {
        [Route("/staff/index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}

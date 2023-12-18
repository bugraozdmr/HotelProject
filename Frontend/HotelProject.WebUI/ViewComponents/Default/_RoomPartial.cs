using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class _RoomPartial : ViewComponent
    {   // invoke olmak zorunda yoksa patlıyor
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

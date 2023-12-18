using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class _HeadPartial : ViewComponent
    {   // default -- invoke
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.RegisterDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        // bu bir class eşleştirmeye gerek yok -- mapping yani
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateNewUserDto createNewUserDto)
        {
            // model hatali gelirse -- model hatalıysa hatası için mapping tarafında eşleştir
            if (!ModelState.IsValid)
            {
                return View();
            }

            var appUser = new AppUser()
            {
                Name = createNewUserDto.Name,
                Email = createNewUserDto.Mail,
                SurName = createNewUserDto.Surname,
                UserName = createNewUserDto.Username
            };
            // user olusuyor
            var result = await _userManager.CreateAsync(appUser,
                createNewUserDto.Password);

            // true donerse
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}

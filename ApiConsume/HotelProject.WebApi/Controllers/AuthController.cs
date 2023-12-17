using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.LoginDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<AppUser> _signInManager;
        public AuthController(SignInManager<AppUser> manager)
        {
            _signInManager = manager;
        }
        [HttpGet("{username}/{password}")]
        public async Task<IActionResult> login(string username,string password)
        {
            // program.cs'de contexti degistir
            var result = await _signInManager.PasswordSignInAsync(username, password, false, false);
            if (result.Succeeded)
            {
                return Ok($"{username} - {password}");
            }

            return BadRequest("password or username incorrect");
        }
    }
}

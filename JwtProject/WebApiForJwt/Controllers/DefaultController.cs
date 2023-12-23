using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiForJwt.Models;

namespace WebApiForJwt.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DefaultController : ControllerBase
	{
		[HttpGet("[action]")]
		public IActionResult createToken()
		{
			return Ok(new CreateToken().TokenCreate());
		}

		[HttpGet("[action]")]
		public IActionResult createAdminToken()
		{
			return Ok(new CreateToken().TokenCreateAdmin());
		}

		[Authorize]
		[HttpGet("[action]")]
		public IActionResult UseToken()
		{
			return Ok("Welcome");
		}

		[Authorize(Roles = "Admin,Visitor")]
		[HttpGet("[action]")]
		public IActionResult UseAdminToken()
		{
			return Ok("Token says hi");
		}
	}
}

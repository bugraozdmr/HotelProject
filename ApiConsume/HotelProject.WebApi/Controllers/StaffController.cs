using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
	// kontroller içini biz yazarız hazır api methodlarını istediğimiz şekilde çağırırız
	[Route("api/[controller]")]
	[ApiController]
	public class StaffController : ControllerBase
	{
		private readonly IStaffService _staffService;

		public StaffController(IStaffService staffService)
		{
			_staffService = staffService;
		}
		// içleri boş giderse sadece get-post ile belirleme yapar ./staff - get req ile // onun yerine ./staf/list olsa daha iyi onun için httpget("list");
		[HttpGet]
		public IActionResult StaffList()
		{
			var values = _staffService.TGetList();
			// response içinde values'de dönsün
			return Ok(values);
		}

		[HttpPost]
		public IActionResult AddStaff(Staff staff)
		{
			_staffService.TInsert(staff);
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteStaff(int id)
		{
			var value = _staffService.TGetById(id);
			_staffService.TDelete(value);
			return Ok();
		}

		[HttpPut]	// swagger otomatik staff verilerini ayarlayacak bizim için
		public IActionResult UpdateStaff(Staff staff)
		{
			_staffService.TUpdate(staff);
			return Ok();
		}

		[HttpGet("{id}")]
		public IActionResult GetStaff(int id)
		{
			var value = _staffService.TGetById(id);
			return Ok(value);
		}
	}
}

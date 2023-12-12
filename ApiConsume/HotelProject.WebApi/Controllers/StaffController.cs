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

		[HttpGet]
		public IActionResult StaffList()
		{
			var values = _staffService.TGetList();
			return Ok(values);
		}

		[HttpPost]
		public IActionResult AddStaff(Staff staff)
		{
			_staffService.TInsert(staff);
			return Ok();
		}

		[HttpDelete]
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

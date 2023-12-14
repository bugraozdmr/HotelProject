using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.RoomDto;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class Room2Controller : ControllerBase
	{
		private readonly IRoomService _roomService;
		private readonly IMapper _mapper;

		public Room2Controller(IRoomService service,IMapper mapper)
		{
			_roomService = service;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult Index()
		{
			var values =  _roomService.TGetList();
			return Ok(values);
		}

		[HttpPost]
		public IActionResult addRoom(RoomAddDto roomAddDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
			// artık hata fırlatıyor -- json'da
			var values = _mapper.Map<Room>(roomAddDto);
			_roomService.TInsert(values);
			return Ok();
		}

		[HttpPut]
		public IActionResult UpdateRoom(UpdateRoomDto updateRoomDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			var values = _mapper.Map<Room>(updateRoomDto);
			_roomService.TUpdate(values);
			return Ok("successfully edited");
		}
	}
}

using HotelNetwork_API_CardonaAndres.DAL.Entities;
using HotelNetwork_API_CardonaAndres.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace HotelNetwork_API_CardonaAndres.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetByNumber/{number}")]
        public async Task<ActionResult<Room>> GetRoomByNumberAsync(int number)
        {
            if (default(int) == number) return BadRequest("Id is required!");

            var room = await _roomService.GetRoomByNumberAsync(number);

            if (room == null)
            {
                return NotFound();
            }
            else if (!room.Availability)
            {
                return BadRequest($"Room {room.Number} of the hotel {room.Hotel?.Name} already booked");
            }

            return Ok(room);
        }
    }
}

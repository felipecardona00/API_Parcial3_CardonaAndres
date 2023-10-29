using HotelNetwork_API_CardonaAndres.DAL.Entities;
using HotelNetwork_API_CardonaAndres.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace HotelNetwork_API_CardonaAndres.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotelsAsync()
        {
            var hotels = await _hotelService.GetHotelsAsync();

            if (hotels == null || !hotels.Any()) return NotFound();

            return Ok(hotels);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")]
        public async Task<ActionResult<Hotel>> GetHotelByIdAsync(Guid id)
        {
            if (id == default) return BadRequest("Id is required!");

            var hotel = await _hotelService.GetHotelByIdAsync(id);

            if (hotel == null) return NotFound();

            return Ok(hotel);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetByCity/{city}")]
        public async Task<ActionResult<Hotel>> GetHotelByCityAsync(string city)
        {
            if (city == null) return BadRequest("City name is required!");

            var hotel = await _hotelService.GetHotelByCityAsync(city);

            if (hotel == null) return NotFound();

            return Ok(hotel);
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit/{id}")]
        public async Task<ActionResult<Hotel>> EditHotelAsync(Guid id, int stars)
        {
            try
            {
                var editedHotel = await _hotelService.EditHotelAsync(id,stars);
                return Ok(editedHotel);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("Hotel with id {0} already exists",id));

                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Hotel>> DeleteHotelAsync(Guid id)
        {
            if (id == default) return BadRequest("Id is required!");

            var deletedHotel = await _hotelService.DeleteHotelAsync(id);

            if (deletedHotel == null) return NotFound("Hotel not found!");

            return Ok(deletedHotel);
        }
    }
}

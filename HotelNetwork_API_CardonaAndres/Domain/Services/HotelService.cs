using HotelNetwork_API_CardonaAndres.DAL;
using HotelNetwork_API_CardonaAndres.DAL.Entities;
using HotelNetwork_API_CardonaAndres.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelNetwork_API_CardonaAndres.Domain.Services
{
    public class HotelService : IHotelService
    {
        private readonly DatabaseContext _context;

        public HotelService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Hotel> CreateHotelAsync(Hotel hotel)
        {
            try
            {
                hotel.Id = Guid.NewGuid();
                hotel.CreatedDate = DateTime.Now;

                _context.Hotels.Add(hotel);
                await _context.SaveChangesAsync();

                return hotel;

            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Hotel?> DeleteHotelAsync(Guid id)
        {
            try
            {
                Hotel? hotel = await _context.Hotels.FirstOrDefaultAsync(h => h.Id == id);
                if (hotel != null)
                {
                    _context.Rooms.RemoveRange(hotel.Rooms.ToList());
                    _context.Hotels.Remove(hotel);
                    await _context.SaveChangesAsync();
                }

                return hotel;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Hotel?> EditHotelAsync(Hotel hotel)
        {
            try
            {
                hotel.ModifiedDate = DateTime.Now;

                _context.Hotels.Update(hotel);
                await _context.SaveChangesAsync();

                return hotel;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Hotel?> GetHotelByCityAsync(string city)
        {
            return await _context.Hotels.Include(h => h.Rooms).FirstOrDefaultAsync(h => h.City == city);
        }

        public async Task<Hotel?> GetHotelByIdAsync(Guid id)
        {
            return await _context.Hotels.Include(h => h.Rooms).FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<IEnumerable<Hotel?>> GetHotelsAsync()
        {
            return await _context.Hotels.Include(h => h.Rooms.Where(r=> r.Availability == true)).ToListAsync();
        }
    }
}

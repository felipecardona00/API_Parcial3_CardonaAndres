using HotelNetwork_API_CardonaAndres.DAL;
using HotelNetwork_API_CardonaAndres.DAL.Entities;
using HotelNetwork_API_CardonaAndres.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelNetwork_API_CardonaAndres.Domain.Services
{
    public class RoomService : IRoomService
    {
        private readonly DatabaseContext _context;

        public RoomService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Room?> GetRoomByNumberAsync(int number)
        {
            return await _context.Rooms.Include(r => r.Hotel).FirstOrDefaultAsync(r => r.Number == number);
        }
    }
}

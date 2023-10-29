using HotelNetwork_API_CardonaAndres.DAL.Entities;

namespace HotelNetwork_API_CardonaAndres.Domain.Interfaces
{
    public interface IRoomService
    {
        Task<Room?> GetRoomByNumberAsync(int number);
    }
}

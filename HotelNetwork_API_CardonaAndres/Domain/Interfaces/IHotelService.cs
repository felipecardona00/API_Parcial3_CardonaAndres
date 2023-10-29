using HotelNetwork_API_CardonaAndres.DAL.Entities;
using System.Diagnostics.Metrics;

namespace HotelNetwork_API_CardonaAndres.Domain.Interfaces
{
    public interface IHotelService
    {
        Task<IEnumerable<Hotel?>> GetHotelsAsync();
        Task<Hotel> CreateHotelAsync(Hotel Hotel);
        Task<Hotel?> GetHotelByIdAsync(Guid id);
        Task<Hotel?> GetHotelByCityAsync(string city);
        Task<Hotel?> EditHotelAsync(Guid id, int stars);
        Task<Hotel?> DeleteHotelAsync(Guid id);
    }
}

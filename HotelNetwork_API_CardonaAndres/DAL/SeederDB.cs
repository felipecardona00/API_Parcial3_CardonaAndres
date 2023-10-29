using HotelNetwork_API_CardonaAndres.DAL.Entities;
using System.Diagnostics.Metrics;

namespace HotelNetwork_API_CardonaAndres.DAL
{
    public class SeederDB
    {
        private readonly DatabaseContext _context;

        public SeederDB(DatabaseContext context)
        {
            _context = context;
        }

        public async Task SeederAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            await PopulateHotelsAsync();

            await _context.SaveChangesAsync();
        }

        #region Private Methos
        private async Task PopulateHotelsAsync()
        {
            if (!_context.Hotels.Any())
            {
                _context.Hotels.Add(new Hotel
                {
                    CreatedDate = DateTime.Now,
                    Name = "Hotel Asturia",
                    City = "Rionegro",
                    Address = "Calle 1 # 1-1",
                    Phone = "123456789",
                    Stars = 3,
                    Rooms = new List<Room>()
                    {
                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = 101,
                            Availability = true,
                            MaxGuests = 5
                        },
                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = 102,
                            Availability = false,
                            MaxGuests = 3
                        },
                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = 201,
                            Availability = true,
                            MaxGuests = 1
                        }
                    }
                });


                _context.Hotels.Add(new Hotel
                {
                    CreatedDate = DateTime.Now,
                    Name = "Hotel Montevideo",
                    City = "Medellin",
                    Address = "Calle 80 # 1-1",
                    Phone = "98765432",
                    Stars = 5,
                    Rooms = new List<Room>()
                    {
                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = 301,
                            Availability = false,
                            MaxGuests = 1
                        },
                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = 302,
                            Availability = false,
                            MaxGuests = 3
                        },
                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = 303,
                            Availability = true,
                            MaxGuests = 4
                        }
                    }
                });

            }
        }

        #endregion
    }
}

using HotelNetwork_API_CardonaAndres.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelNetwork_API_CardonaAndres.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Hotel>().HasIndex("Name","City", "Address").IsUnique();
            modelBuilder.Entity<Room>().HasIndex("Number","HotelId").IsUnique();
        }

        #region
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }

        #endregion
    }
}

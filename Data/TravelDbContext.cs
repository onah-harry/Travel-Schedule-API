using Microsoft.EntityFrameworkCore;
using TravelSchedule.BackService.Models;

namespace TravelSchedule.BackService.Data
{
    public class TravelDbContext : DbContext
    {
        public TravelDbContext(DbContextOptions<TravelDbContext> options) : base(options)
        {
        }

        public DbSet<Traveller> Travellers { get; set; }
        public DbSet<Travel> Travels { get; set; }
        public DbSet<Accomodation> Accomodations { get; set; }
        public DbSet<CompletedTravel> CompletedTravels { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Travel>(entity =>
        //    {
        //        entity.HasData(new Travel
        //        {
        //            Destination = "Cookies",
        //            UserId = 1,
        //            Email = "harry@gnitech.com",
        //            Password = "akara@1",
        //            FirstName = "Harry",
        //            LastName = "Guy",
        //            Mobile = "704-1020-235",
        //            Roles = "Admin"
        //        });
        //    });
        //}

    }
}


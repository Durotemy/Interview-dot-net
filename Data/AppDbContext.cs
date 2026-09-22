using Microsoft.EntityFrameworkCore;
using TravelApi.Entities;
// using learning.Models;

namespace TravelApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<RoomsBooking> RoomsBookings => Set<RoomsBooking>();

    public DbSet<FlightBooking> FlightBookings => Set<FlightBooking>();

    public DbSet<Room> Rooms => Set<Room>();

    public DbSet<Package> Packages => Set<Package>();

    public DbSet<Customer> Customers => Set<Customer>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Customer>().HasIndex(c => c.Username).IsUnique();
        builder.Entity<Customer>().HasIndex(c => c.Email).IsUnique();
    }

}


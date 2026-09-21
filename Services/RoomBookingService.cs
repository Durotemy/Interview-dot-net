using Microsoft.EntityFrameworkCore;
using TravelApi.Entities;
using TravelApi.Enums;
using TravelApi.Services;
using TravelApi.Data;

namespace TravelApi.Services;

public interface IRoomBookingService
{
    Task<List<RoomsBooking>> GetAllAsync(Guid customerId);
    Task<(RoomsBooking? Booking, string? Error)> CreateAsync(Guid customerId, RoomsBooking booking);

}

public class RoomBookingService : IRoomBookingService
{
    readonly AppDbContext _db;

    public RoomBookingService(AppDbContext db)

    {
        _db = db;
    }

    public async Task<List<RoomsBooking>> GetAllAsync(Guid customerId)
    {
        return await _db.RoomsBookings
            .Include(b => b.Room)
            .Where(b => b.CustomerId == customerId)
            .OrderByDescending(b => b.CheckIn)
            .ToListAsync();
    }
    public async Task<(RoomsBooking? Booking, string? Error)> CreateAsync(Guid customerId, RoomsBooking booking)
    {
        if (booking.CheckOut <= booking.CheckIn)
            return (null, "Check-out must be after check-in.");

        if (booking.CheckIn < DateOnly.FromDateTime(DateTime.UtcNow))
            return (null, "Check-in cannot be in the past.");

        if (booking.NumberOfRooms < 1)
            return (null, "Book at least one room.");

        var customer = await _db.Customers.FirstOrDefaultAsync(c => c.Id == customerId);
        if (customer == null)
            return (null, "Customer not found.");

        var room = await _db.Rooms.FirstOrDefaultAsync(r => r.Id == booking.RoomId);
        if (room == null)
            return (null, "Room not found.");

        var alreadyBooked = await _db.RoomsBookings
            .Where(b => b.RoomId == booking.RoomId
                     && b.RoomStatus != RequestStatus.Unavailable
                     && b.CheckIn < booking.CheckOut
                     && b.CheckOut > booking.CheckIn)
            .SumAsync(b => b.NumberOfRooms);

        var roomsLeft = room.TotalRooms - alreadyBooked;
        if (booking.NumberOfRooms > roomsLeft)
            return (null, $"Only {Math.Max(roomsLeft, 0)} room(s) left for those dates.");

        booking.Id = Guid.NewGuid();
        booking.CustomerId = customerId;
        booking.RoomStatus = RequestStatus.Confirmed;
        _db.RoomsBookings.Add(booking);
        await _db.SaveChangesAsync();

        return (booking, null);
    }
}


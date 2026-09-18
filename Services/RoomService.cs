using Microsoft.EntityFrameworkCore;
using TravelApi.Entities;
using TravelApi.Enums;
using TravelApi.Data;

namespace TravelApi.Services;

public interface IRoom
{
    Task<List<Room>> GetAllAsync();
    Task<Room?> GetByIdAsync(Guid customerId);
    Task<Room> CreateAsync(Room room);
    Task<(int? RoomsLeft, string? Error)> GetAvailabilityAsync(Guid roomId, DateOnly checkIn, DateOnly checkOut);
}

public class RoomService : IRoom
{
    readonly AppDbContext _db;

    public RoomService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<Room>> GetAllAsync()
    {
        return await _db.Rooms
            .ToListAsync();
    }
    public async Task<Room?> GetByIdAsync(Guid id)
    {
        return await _db.Rooms
        .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<Room> CreateAsync(Room room)
    {
        room.Id = Guid.NewGuid();
        _db.Rooms.Add(room);
        await _db.SaveChangesAsync();
        return room;
    }

    public async Task<(int? RoomsLeft, string? Error)> GetAvailabilityAsync(Guid roomId, DateOnly checkIn, DateOnly checkOut)
    {
        if (checkOut <= checkIn)
            return (null, "Check-out must be after check-in.");

        var room = await _db.Rooms.FirstOrDefaultAsync(r => r.Id == roomId);
        if (room == null)
            return (null, "Room not found.");

        var alreadyBooked = await _db.RoomsBookings
            .Where(b => b.RoomId == roomId
                     && b.RoomStatus != RequestStatus.Unavailable
                     && b.CheckIn < checkOut
                     && b.CheckOut > checkIn)
            .SumAsync(b => b.NumberOfRooms);

        return (Math.Max(room.TotalRooms - alreadyBooked, 0), null);
    }
}
using Microsoft.EntityFrameworkCore;
using TravelApi.Entities;
using TravelApi.Data;

namespace TravelApi.Services;

public interface IRoom
{
    Task<List<Room>> GetAllAsync();
    Task<Room?> GetByIdAsync(Guid customerId);
    Task<Room> CreateAsync(Room room);
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
}
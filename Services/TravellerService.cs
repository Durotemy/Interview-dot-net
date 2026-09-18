using Microsoft.EntityFrameworkCore;
using TravelApi.Entities;
using TravelApi.Data;


namespace TravelApi.Services;

public interface ITravellerService
{
    Task<List<Traveller>> GetAllAsync(Guid customerId);
    Task<Traveller?> GetByIdAsync(Guid customerId, Guid id);
    Task<(Traveller? Traveller, string? Error)> CreateAsync(Guid customerId, Traveller traveller);
    Task<bool> DeleteAsync(Guid customerId, Guid id);
}

public class TravellerService : ITravellerService
{
    readonly AppDbContext _db;

    public TravellerService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<Traveller>> GetAllAsync(Guid customerId)
    {
        return await _db.Travellers
            .Where(t => t.CustomerId == customerId)
            .ToListAsync();
    }

    public async Task<(Traveller? Traveller, string? Error)> CreateAsync(Guid customerId, Traveller traveller)
    {
        var duplicate = await _db.Travellers.AnyAsync(t =>
            t.CustomerId == customerId &&
            t.FirstName == traveller.FirstName &&
            t.LastName == traveller.LastName &&
            t.DateOfBirth == traveller.DateOfBirth);

        if (duplicate)
            return (null, "Traveller already exists.");

        traveller.CustomerId = customerId;
        _db.Travellers.Add(traveller);
        await _db.SaveChangesAsync();
        return (traveller, null);
    }

    public async Task<Traveller?> GetByIdAsync(Guid customerId, Guid id)
    {
        return await _db.Travellers
            .FirstOrDefaultAsync(t => t.Id == id && t.CustomerId == customerId);
    }

    public async Task<bool> DeleteAsync(Guid customerId, Guid id)
    {
        var traveller = await _db.Travellers
        .FirstOrDefaultAsync(t => t.Id == id && t.CustomerId == customerId);

        if (traveller == null)
        {
            return false;
        }
        _db.Travellers.Remove(traveller);
        await _db.SaveChangesAsync();
        return true;
    }
}
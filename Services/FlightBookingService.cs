using Microsoft.EntityFrameworkCore;
using TravelApi.Entities;
using TravelApi.Enums;
using TravelApi.Data;

namespace TravelApi.Services;

public interface IFlightBooking
{
    Task<List<FlightBooking>> GetAllAsync(Guid customerId);
    Task<FlightBooking?> GetByIdAsync(Guid customerId, Guid id);
    Task<FlightBooking> CreateAsync(Guid id, FlightBooking flightBooking);
    Task<FlightBooking?> UpdatePreferencesAsync(Guid customerId, Guid id, MealPreference meal, SeatPreference seat);

}

public class FlightBookingService : IFlightBooking
{
    readonly AppDbContext _db;

    public FlightBookingService(AppDbContext db)
    {
        _db = db;
    }
    public async Task<List<FlightBooking>> GetAllAsync(Guid customerId)

    {
        return await _db.FlightBookings
            .Include(f => f.Traveller)
            .Where(f => f.Traveller!.CustomerId == customerId)
            .ToListAsync();
    }

    public async Task<FlightBooking?> GetByIdAsync(Guid customerId, Guid id)
    {
        return await _db.FlightBookings
        .Include(t => t.Traveller)
        .FirstOrDefaultAsync(t => t.Id == id && t.Traveller!.CustomerId == customerId);
    }
    public async Task<FlightBooking> CreateAsync(Guid customerId, FlightBooking flightBooking)
    {
        var traveller = await _db.Travellers.FirstOrDefaultAsync(t => t.Id == flightBooking.TravellerId && t.CustomerId == customerId);

        if (traveller == null)
        {
            return null;
        }

        flightBooking.Id = Guid.NewGuid();
        flightBooking.MealStatus = RequestStatus.Requested;
        flightBooking.SeatStatus = RequestStatus.Requested;
        flightBooking.AssignedSeat = null;

        _db.FlightBookings.Add(flightBooking);
        await _db.SaveChangesAsync();

        return flightBooking;


    }

    public async Task<FlightBooking?> UpdatePreferencesAsync(Guid customerId, Guid id, MealPreference meal, SeatPreference seat)
    {
        var booking = await _db.FlightBookings
            .Include(t => t.Traveller)
            .FirstOrDefaultAsync(t => t.Id == id && t.Traveller!.CustomerId == customerId);

        if (booking == null)
        {
            return null;
        }

        booking.Meal = meal;
        booking.SeatPreference = seat;
        booking.MealStatus = RequestStatus.Requested;
        booking.SeatStatus = RequestStatus.Requested;
        booking.AssignedSeat = null;

        await _db.SaveChangesAsync();
        return booking;
    }


}
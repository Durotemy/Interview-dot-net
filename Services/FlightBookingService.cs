using Microsoft.EntityFrameworkCore;
using TravelApi.Entities;
using TravelApi.Enums;
using TravelApi.Data;

namespace TravelApi.Services;

public interface IFlightBooking
{
    Task<List<FlightBooking>> GetAllAsync(Guid customerId);
    Task<FlightBooking?> GetByIdAsync(Guid customerId, Guid id);
    Task<(FlightBooking? Booking, string? Error)> CreateAsync(Guid id, FlightBooking flightBooking);
    Task<FlightBooking?> UpdatePreferencesAsync(Guid customerId, Guid id, MealPreference meal, SeatPreference seat);

}

public class FlightBookingService : IFlightBooking
{
    const int PlaneCapacity = 99;
    static readonly Random _random = new();

    readonly AppDbContext _db;

    public FlightBookingService(AppDbContext db)
    {
        _db = db;
    }
    public async Task<List<FlightBooking>> GetAllAsync(Guid customerId)

    {
        return await _db.FlightBookings
            .Where(f => f.CustomerId == customerId)
            .ToListAsync();
    }

    public async Task<FlightBooking?> GetByIdAsync(Guid customerId, Guid id)
    {
        return await _db.FlightBookings
        .FirstOrDefaultAsync(f => f.Id == id && f.CustomerId == customerId);
    }
    public async Task<(FlightBooking? Booking, string? Error)> CreateAsync(Guid customerId, FlightBooking flightBooking)
    {
        var customer = await _db.Customers.FirstOrDefaultAsync(c => c.Id == customerId);

        if (customer == null)
        {
            return (null, "Customer not found.");
        }

        flightBooking.Id = Guid.NewGuid();
        flightBooking.CustomerId = customerId;
        flightBooking.MealStatus = RequestStatus.Requested;

        if (customer.SecurityConcerns)
        {
            // Flagged customers need manual clearance before a seat is assigned.
            flightBooking.SeatStatus = RequestStatus.Requested;
            flightBooking.AssignedSeat = null;
        }
        else
        {
            var takenSeats = await _db.FlightBookings
                .Where(f => f.FlightNumber == flightBooking.FlightNumber
                         && f.DepartureDate == flightBooking.DepartureDate
                         && f.AssignedSeat != null)
                .Select(f => f.AssignedSeat!)
                .ToListAsync();

            var availableSeats = Enumerable.Range(1, PlaneCapacity)
                .Select(n => n.ToString())
                .Except(takenSeats)
                .ToList();

            if (availableSeats.Count == 0)
            {
                return (null, "Flight is fully booked.");
            }

            flightBooking.AssignedSeat = availableSeats[_random.Next(availableSeats.Count)];
            flightBooking.SeatStatus = RequestStatus.Confirmed;
        }

        _db.FlightBookings.Add(flightBooking);
        await _db.SaveChangesAsync();

        return (flightBooking, null);
    }

    public async Task<FlightBooking?> UpdatePreferencesAsync(Guid customerId, Guid id, MealPreference meal, SeatPreference seat)
    {
        var booking = await _db.FlightBookings
            .FirstOrDefaultAsync(f => f.Id == id && f.CustomerId == customerId);

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
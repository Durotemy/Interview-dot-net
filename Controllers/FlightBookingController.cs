using Microsoft.AspNetCore.Mvc;
using TravelApi.Entities;
using TravelApi.Enums;
using TravelApi.Services;

namespace TravelApi.Controllers;

[ApiController]
[Route("api/v1/customers/{customerId:guid}/flight-bookings")]
public class FlightBookingController : ControllerBase
{
    private readonly IFlightBooking _flightBookingService;

    public FlightBookingController(IFlightBooking flightBookingService)
    {
        _flightBookingService = flightBookingService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(Guid customerId)
    {
        var bookings = await _flightBookingService.GetAllAsync(customerId);
        return Ok(bookings);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid customerId, Guid id)
    {
        var booking = await _flightBookingService.GetByIdAsync(customerId, id);
        if (booking == null)
        {
            return NotFound();
        }
        return Ok(booking);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Guid customerId, [FromBody] FlightBooking flightBooking)
    {
        var (created, error) = await _flightBookingService.CreateAsync(customerId, flightBooking);
        if (error != null)
        {
            return BadRequest(error);
        }
        return Ok(created);
    }

    [HttpPut("{id:guid}/preferences")]
    public async Task<IActionResult> UpdatePreferences(Guid customerId, Guid id, [FromBody] UpdatePreferencesRequest request)
    {
        var updated = await _flightBookingService.UpdatePreferencesAsync(customerId, id, request.Meal, request.SeatPreference);
        if (updated == null)
        {
            return NotFound();
        }
        return Ok(updated);
    }
}

public class UpdatePreferencesRequest
{
    public MealPreference Meal { get; set; }
    public SeatPreference SeatPreference { get; set; }
}

using Microsoft.AspNetCore.Mvc;
using TravelApi.Services;

namespace TravelApi.Controllers;

[ApiController]
[Route("api/v1/admin/customers/{customerId:guid}/flight-bookings")]
public class ConfirmBookingController : ControllerBase
{
    private readonly IFlightBooking _flightBookingService;

    public ConfirmBookingController(IFlightBooking flightBookingService)
    {
        _flightBookingService = flightBookingService;
    }

    [HttpPost("{id:guid}/confirm")]
    public async Task<IActionResult> Confirm(Guid customerId, Guid id)
    {
        var (confirmed, error) = await _flightBookingService.ConfirmBookingAsync(customerId, id);

        if (error == "Booking not found.")
        {
            return NotFound(error);
        }

        if (error != null)
        {
            return StatusCode(StatusCodes.Status403Forbidden, error);
        }

        return Ok(new
        {
            message = "Flight booking confirmed.",
            assignedSeat = confirmed!.AssignedSeat,
            booking = confirmed
        });
    }
}

public record ConfirmBookingRequest(string? Seat);
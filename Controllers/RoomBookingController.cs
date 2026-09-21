using Microsoft.AspNetCore.Mvc;
using TravelApi.Entities;
using TravelApi.Services;

namespace TravelApi.Controllers;

[ApiController]
[Route("api/v1/customers/{customerId:guid}/room-bookings")]
public class RoomBookingController : ControllerBase
{
    private readonly IRoomBookingService _bookingService;

    public RoomBookingController(IRoomBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(Guid customerId)
    {
        var bookings = await _bookingService.GetAllAsync(customerId);
        return Ok(bookings);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Guid customerId, RoomsBooking booking)
    {
        var (created, error) = await _bookingService.CreateAsync(customerId, booking);
        if (error != null)
        {
            return BadRequest(error);
        }
        return Ok(created);
    }
}
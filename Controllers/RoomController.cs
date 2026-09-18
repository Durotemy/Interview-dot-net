using TravelApi.Entities;
using TravelApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace TravelApi.Controllers;

[ApiController]
[Route("api/v1/rooms")]
public class RoomController : ControllerBase

{
    private readonly IRoom _roomService;

    public RoomController(IRoom roomService)
    {
        _roomService = roomService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var rooms = await _roomService.GetAllAsync();
        return Ok(rooms);
    }
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var room = await _roomService.GetByIdAsync(id);
        if (room == null)
        {
            return NotFound();
        }
        return Ok(room);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Room room)
    {
        var created = await _roomService.CreateAsync(room);
        return Ok(created);
    }

}


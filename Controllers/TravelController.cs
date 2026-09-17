using Microsoft.AspNetCore.Mvc;
using TravelApi.Entities;
using TravelApi.Services;

namespace TravelApi.Controllers;

[ApiController]
[Route("api/v1/customers/{customerId:guid}/travellers")]
public class TravellersController : ControllerBase
{
    private readonly ITravellerService _travellerService;

    public TravellersController(ITravellerService travellerService)
    {
        _travellerService = travellerService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Guid customerId, [FromBody] Traveller traveller)
    {
        var created = await _travellerService.CreateAsync(customerId, traveller);
        return Ok(created);
    }

    [HttpGet]

    public async Task<IActionResult> GetAll(Guid customerId)
    {
        var travellers = await _travellerService.GetAllAsync(customerId);
        return Ok(travellers);
    }
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid customerId)
    {
        var traveller = await _travellerService.GetByIdAsync(customerId);
        if (traveller == null)
        {
            return NotFound();
        }
        return Ok(traveller);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid customerId, Guid id)
    {
        var deleted = await _travellerService.DeleteAsync(customerId, id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
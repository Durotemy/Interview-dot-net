using Microsoft.AspNetCore.Mvc;
using TravelApi.Entities;
using TravelApi.Services;
using TravelApi.Dto;

namespace TravelApi.Controllers;

[ApiController]
[Route("api/v1/customers")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var (created, error) = await _customerService.RegisterAsync(request);
        if (error != null)
        {
            return BadRequest(error);
        }
        return Ok(created);
    }
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var customer = await _customerService.GetByIdAsync(id);
        if (customer == null)
        {
            return NotFound();
        }
        return Ok(customer);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DelById(Guid id)
    {
        var customer = await _customerService.DeleteByIdAsync(id);
        if (customer == null)
        {
            return NotFound();
        }

        return Ok(customer);
    }
}

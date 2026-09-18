using Microsoft.AspNetCore.Mvc;
using TravelApi.Entities;
using TravelApi.Services;

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
    public async Task<IActionResult> Register(Customer customer)
    {
        var (created, error) = await _customerService.RegisterAsync(customer);
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
}

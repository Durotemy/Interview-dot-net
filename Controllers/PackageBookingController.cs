using Microsoft.AspNetCore.Mvc;
using TravelApi.Services;

namespace TravelApi.Controllers;

[ApiController]
[Route("api/v1/customers/{customerId:guid}/packages/{packageId:guid}/bookings")]
public class PackageBookingController : ControllerBase
{
    private readonly IPackageService _packageService;

    public PackageBookingController(IPackageService packageService)
    {
        _packageService = packageService;
    }

    [HttpPost]
    public async Task<IActionResult> Book(Guid customerId, Guid packageId, [FromBody] PackageBookingRequest request)
    {
        var (result, error) = await _packageService.BookAsync(customerId, packageId, request);
        if (error != null)
        {
            return BadRequest(error);
        }
        return Ok(result);
    }
}

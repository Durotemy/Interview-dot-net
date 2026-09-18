using Microsoft.AspNetCore.Mvc;
using TravelApi.Entities;
using TravelApi.Services;

namespace TravelApi.Controllers;

[ApiController]
[Route("api/v1/packages")]
public class PackageController : ControllerBase
{
    private readonly IPackageService _packageService;

    public PackageController(IPackageService packageService)
    {
        _packageService = packageService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var packages = await _packageService.GetAllAsync();
        return Ok(packages);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var package = await _packageService.GetByIdAsync(id);
        if (package == null)
        {
            return NotFound();
        }
        return Ok(package);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Package package)
    {
        var created = await _packageService.CreateAsync(package);
        return Ok(created);
    }
}

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace TravelApi.Controllers;

public static class ControllerExtensions
{
    public static bool IsCurrentCustomer(this ControllerBase controller, Guid customerId)
    {
        var sub = controller.User.FindFirstValue(ClaimTypes.NameIdentifier)
                  ?? controller.User.FindFirstValue(JwtRegisteredClaimNames.Sub);
        return Guid.TryParse(sub, out var id) && id == customerId;
    }
}

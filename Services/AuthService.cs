
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TravelApi.Data;
using TravelApi.Dto;

namespace TravelApi.Services;

public interface IAuthService
{
    Task<(AuthResponse? Result, string? Error)> LoginAsync(LoginRequest request);
}

public class AuthService : IAuthService
{
    readonly AppDbContext _db;
    readonly IConfiguration _config;

    public AuthService(AppDbContext db, IConfiguration config)
    {
        _db = db;
        _config = config;
    }

    public async Task<(AuthResponse? Result, string? Error)> LoginAsync(LoginRequest request)
    {
        var customer = await _db.Customers.FirstOrDefaultAsync(c => c.Username == request.Username);
        if (customer is null || !BCrypt.Net.BCrypt.Verify(request.Password, customer.PasswordHash))
            return (null, "Invalid username or password.");

        var minutes = _config.GetValue<int>("Jwt:AccessTokenMinutes");
        var expires = DateTime.UtcNow.AddMinutes(minutes);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, customer.Id.ToString()),
            new Claim("unique_name", customer.Username),
            new Claim(JwtRegisteredClaimNames.Email, customer.Email),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Secret"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: expires,
            signingCredentials: creds);

        var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
        return (new AuthResponse(accessToken, expires), null);
    }
}
namespace TravelApi.Dto;

public record RegisterRequest(string FirstName, string LastName, string Email, string PhoneNumber, string Username, string Password);

public record LoginRequest(string Username, string Password);

public record AuthResponse(string AccessToken, DateTime ExpiresAt);
namespace TravelApi.Entities;

public class Customer
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; } = "";
    public required string LastName { get; set; } = "";
    public required string Email { get; set; } = "";
    public DateOnly DateOfBirth { get; set; }
    public required string Nationality { get; set; } = "";
    public required bool Disabilty { get; set; } = false;
    public required string PhoneNumber { get; set; } = "";
    public bool SecurityConcerns { get; set; } = false;
}

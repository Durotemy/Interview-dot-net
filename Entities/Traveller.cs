namespace TravelApi.Entities;

public class Traveller
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }

    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public DateOnly DateOfBirth { get; set; }

    public bool SecurityConcerns { get; set; } = false;
}
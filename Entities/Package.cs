namespace TravelApi.Entities;

public class Package
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";

    public Guid RoomId { get; set; }
    public Room? Room { get; set; }

    public string FlightNumber { get; set; } = "";
    public string Origin { get; set; } = "";
    public string Destination { get; set; } = "";

    public decimal Price { get; set; }
}

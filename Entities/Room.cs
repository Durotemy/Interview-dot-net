using TravelApi.Enums;
namespace TravelApi.Entities;

public class Room
{
    public Guid Id { get; set; }
    public string HotelName { get; set; } = "";
    public string City { get; set; } = "";
    public RoomCategory Category { get; set; } = RoomCategory.Standard;
    public decimal PricePerNight { get; set; }
    public int TotalRooms { get; set; }
}
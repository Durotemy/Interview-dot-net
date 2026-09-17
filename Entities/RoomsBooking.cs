using TravelApi.Enums;

namespace TravelApi.Entities;

public class RoomsBooking
{
    public Guid Id { get; set; }
    public Guid RoomId { get; set; }
    public Room? Room { get; set; }
    public DateOnly CheckIn { get; set; }
    public DateOnly CheckOut { get; set; }
    public int NumberOfRooms { get; set; } = 1;
    public RequestStatus RoomStatus { get; set; } = RequestStatus.Requested;
    public Guid TravellerId { get; set; }
    public Traveller? Traveller { get; set; }

}
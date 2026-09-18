using TravelApi.Enums;

namespace TravelApi.Entities;

public class FlightBooking
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public string FlightNumber { get; set; } = "";
    public string Origin { get; set; } = "";
    public string Destination { get; set; } = "";
    public DateOnly DepartureDate { get; set; }
    public MealPreference Meal { get; set; } = MealPreference.Standard;
    public RequestStatus MealStatus { get; set; } = RequestStatus.Requested;
    public SeatPreference SeatPreference { get; set; } = SeatPreference.NoPreference;
    public string? AssignedSeat { get; set; }
    public RequestStatus SeatStatus { get; set; } = RequestStatus.Requested;
    public Customer? Customer { get; set; }
}


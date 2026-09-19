using Microsoft.EntityFrameworkCore;
using TravelApi.Entities;
using TravelApi.Enums;
using TravelApi.Data;

namespace TravelApi.Services;

public class PackageBookingRequest
{
    public DateOnly CheckIn { get; set; }
    public DateOnly CheckOut { get; set; }
    public int NumberOfRooms { get; set; } = 1;
    public DateOnly DepartureDate { get; set; }
    public MealPreference Meal { get; set; } = MealPreference.Standard;
    public SeatPreference SeatPreference { get; set; } = SeatPreference.NoPreference;
}

public class PackageBookingResult
{
    public RoomsBooking RoomBooking { get; set; } = null!;
    public FlightBooking FlightBooking { get; set; } = null!;
}

public interface IPackageService
{
    Task<List<Package>> GetAllAsync();
    Task<Package?> GetByIdAsync(Guid id);
    Task<Package> CreateAsync(Package package);
    Task<(PackageBookingResult? Result, string? Error)> BookAsync(Guid customerId, Guid packageId, PackageBookingRequest request);
}

public class PackageService : IPackageService
{
    readonly AppDbContext _db;
    readonly IRoomBookingService _roomBookingService;
    readonly IFlightBooking _flightBookingService;

    public PackageService(AppDbContext db, IRoomBookingService roomBookingService, IFlightBooking flightBookingService)
    {
        _db = db;
        _roomBookingService = roomBookingService;
        _flightBookingService = flightBookingService;
    }

    public async Task<List<Package>> GetAllAsync()
    {
        return await _db.Packages
            .Include(p => p.Room)
            .ToListAsync();
    }

    public async Task<Package?> GetByIdAsync(Guid id)
    {
        return await _db.Packages
            .Include(p => p.Room)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Package> CreateAsync(Package package)
    {
        package.Id = Guid.NewGuid();
        _db.Packages.Add(package);
        await _db.SaveChangesAsync();
        return package;
    }

    public async Task<(PackageBookingResult? Result, string? Error)> BookAsync(Guid customerId, Guid packageId, PackageBookingRequest request)
    {
        var package = await _db.Packages.FirstOrDefaultAsync(p => p.Id == packageId);
        if (package == null)
            return (null, "Package not foud.");

        await using var transaction = await _db.Database.BeginTransactionAsync();

        var roomBooking = new RoomsBooking
        {
            RoomId = package.RoomId,
            CheckIn = request.CheckIn,
            CheckOut = request.CheckOut,
            NumberOfRooms = request.NumberOfRooms,
        };

        var (createdRoomBooking, roomError) = await _roomBookingService.CreateAsync(customerId, roomBooking);
        if (roomError != null)
        {
            await transaction.RollbackAsync();
            return (null, roomError);
        }

        var flightBooking = new FlightBooking
        {
            FlightNumber = package.FlightNumber,
            Origin = package.Origin,
            Destination = package.Destination,
            DepartureDate = request.DepartureDate,
            Meal = request.Meal,
            SeatPreference = request.SeatPreference,
        };

        var (createdFlightBooking, flightError) = await _flightBookingService.CreateAsync(customerId, flightBooking);
        if (flightError != null)
        {
            await transaction.RollbackAsync();
            return (null, flightError);
        }

        await transaction.CommitAsync();

        return (new PackageBookingResult
        {
            RoomBooking = createdRoomBooking!,
            FlightBooking = createdFlightBooking!
        }, null);
    }
}

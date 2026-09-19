# Graph Report - travelApp  (2026-09-19)

## Corpus Check
- 61 files · ~12,966 words
- Verdict: corpus is large enough that graph structure adds value.

## Summary
- 277 nodes · 538 edges · 21 communities
- Extraction: 96% EXTRACTED · 4% INFERRED · 0% AMBIGUOUS · INFERRED: 20 edges (avg confidence: 0.8)
- Token cost: 0 input · 0 output

## Graph Freshness
- Built from commit: `32721e09`
- Run `git rev-parse HEAD` and compare to check if the graph is stale.
- Run `graphify update .` after code changes (no API cost).

## Community Hubs (Navigation)
- Package
- FlightBooking
- AddTravellerIsSelf
- .Confirm
- RoomsBooking
- AppDbContext
- TravelApi.Entities
- http
- learning4.csproj
- Customer
- AppDbContextModelSnapshot.cs
- InitialCreate
- Migration
- AddPackages
- AddCustomers
- AddCustomerDetails
- learning4.Migrations

## God Nodes (most connected - your core abstractions)
1. `FlightBooking` - 20 edges
2. `TravelApi.Entities` - 16 edges
3. `TravelApi.Data` - 15 edges
4. `learning4.Migrations` - 15 edges
5. `AppDbContext` - 13 edges
6. `Room` - 13 edges
7. `RoomsBooking` - 13 edges
8. `TravelApi.Services` - 13 edges
9. `TravelApi.Enums` - 12 edges
10. `Customer` - 11 edges

## Surprising Connections (you probably didn't know these)
- `ConfirmBookingController` --references--> `IFlightBooking`  [EXTRACTED]
  Controllers/ConfirmBookingController.cs → Services/FlightBookingService.cs
- `AppDbContext` --references--> `Customer`  [EXTRACTED]
  Data/AppDbContext.cs → Entities/Customer.cs
- `AppDbContext` --references--> `FlightBooking`  [EXTRACTED]
  Data/AppDbContext.cs → Entities/FlightBooking.cs
- `AppDbContext` --references--> `Package`  [EXTRACTED]
  Data/AppDbContext.cs → Entities/Package.cs
- `AppDbContext` --references--> `RoomsBooking`  [EXTRACTED]
  Data/AppDbContext.cs → Entities/RoomsBooking.cs

## Import Cycles
- None detected.

## Communities (21 total, 0 thin omitted)

### Community 0 - "Package"
Cohesion: 0.10
Nodes (23): Guid, HttpPost, IActionResult, Task, PackageBookingController, Guid, HttpGet, HttpPost (+15 more)

### Community 1 - "FlightBooking"
Cohesion: 0.14
Nodes (22): Guid, HttpGet, HttpPost, IActionResult, Task, FlightBookingController, UpdatePreferencesRequest, DateOnly (+14 more)

### Community 2 - "AddTravellerIsSelf"
Cohesion: 0.29
Nodes (3): MigrationBuilder, ModelBuilder, AddTravellerIsSelf

### Community 3 - ".Confirm"
Cohesion: 0.25
Nodes (6): Guid, HttpPost, IActionResult, Task, ConfirmBookingController, ConfirmBookingRequest

### Community 4 - "RoomsBooking"
Cohesion: 0.14
Nodes (18): ControllerBase, Guid, HttpGet, HttpPost, IActionResult, Task, RoomBookingController, DateOnly (+10 more)

### Community 5 - "AppDbContext"
Cohesion: 0.11
Nodes (21): DateOnly, Guid, HttpGet, HttpPost, IActionResult, Task, RoomController, AppDbContext (+13 more)

### Community 6 - "TravelApi.Entities"
Cohesion: 0.19
Nodes (6): TravelApi.Entities, TravelApi.Enums, TravelApi.Data, TravelApi.Controllers, TravelApi.Services, WeatherForecast

### Community 7 - "http"
Cohesion: 0.13
Nodes (15): ASPNETCORE_ENVIRONMENT, applicationUrl, commandName, dotnetRunMessages, environmentVariables, launchBrowser, applicationUrl, commandName (+7 more)

### Community 8 - "learning4.csproj"
Cohesion: 0.33
Nodes (5): net10.0, Microsoft.AspNetCore.OpenApi (10.0.10), Microsoft.EntityFrameworkCore.Design (10.0.12), Npgsql.EntityFrameworkCore.PostgreSQL (10.0.3), Microsoft.NET.Sdk.Web

### Community 13 - "Customer"
Cohesion: 0.15
Nodes (15): Guid, HttpGet, HttpPost, IActionResult, Task, CustomerController, DateOnly, Guid (+7 more)

### Community 14 - "AppDbContextModelSnapshot.cs"
Cohesion: 0.40
Nodes (3): ModelBuilder, AppDbContextModelSnapshot, ModelSnapshot

### Community 15 - "InitialCreate"
Cohesion: 0.29
Nodes (3): MigrationBuilder, ModelBuilder, InitialCreate

### Community 16 - "Migration"
Cohesion: 0.25
Nodes (4): Migration, MigrationBuilder, ModelBuilder, AddRooms

### Community 17 - "AddPackages"
Cohesion: 0.29
Nodes (3): MigrationBuilder, ModelBuilder, AddPackages

### Community 18 - "AddCustomers"
Cohesion: 0.29
Nodes (3): MigrationBuilder, ModelBuilder, AddCustomers

### Community 19 - "AddCustomerDetails"
Cohesion: 0.29
Nodes (3): MigrationBuilder, ModelBuilder, AddCustomerDetails

### Community 20 - "learning4.Migrations"
Cohesion: 0.28
Nodes (4): learning4.Migrations, MigrationBuilder, ModelBuilder, MergeTravellerIntoCustomer

## Knowledge Gaps
- **16 isolated node(s):** `ConfirmBookingRequest`, `WeatherForecast`, `$schema`, `commandName`, `dotnetRunMessages` (+11 more)
  These have ≤1 connection - possible missing edges or undocumented components.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `TravelApi.Data` connect `TravelApi.Entities` to `AddTravellerIsSelf`, `AppDbContextModelSnapshot.cs`, `InitialCreate`, `Migration`, `AddPackages`, `AddCustomers`, `AddCustomerDetails`, `learning4.Migrations`?**
  _High betweenness centrality (0.320) - this node is a cross-community bridge._
- **Why does `AppDbContext` connect `AppDbContext` to `Package`, `FlightBooking`, `RoomsBooking`, `TravelApi.Entities`, `Customer`?**
  _High betweenness centrality (0.125) - this node is a cross-community bridge._
- **Why does `FlightBooking` connect `FlightBooking` to `Package`, `RoomsBooking`, `AppDbContext`, `TravelApi.Entities`, `Customer`?**
  _High betweenness centrality (0.091) - this node is a cross-community bridge._
- **What connects `ConfirmBookingRequest`, `WeatherForecast`, `$schema` to the rest of the system?**
  _16 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `Package` be split into smaller, more focused modules?**
  _Cohesion score 0.10476190476190476 - nodes in this community are weakly interconnected._
- **Should `FlightBooking` be split into smaller, more focused modules?**
  _Cohesion score 0.14285714285714285 - nodes in this community are weakly interconnected._
- **Should `RoomsBooking` be split into smaller, more focused modules?**
  _Cohesion score 0.14 - nodes in this community are weakly interconnected._
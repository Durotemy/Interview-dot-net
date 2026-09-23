# Graph Report - travelApp  (2026-09-22)

## Corpus Check
- 67 files · ~14,923 words
- Verdict: corpus is large enough that graph structure adds value.

## Summary
- 316 nodes · 601 edges · 24 communities
- Extraction: 97% EXTRACTED · 3% INFERRED · 0% AMBIGUOUS · INFERRED: 21 edges (avg confidence: 0.8)
- Token cost: 0 input · 0 output

## Graph Freshness
- Built from commit: `d42011d8`
- Run `git rev-parse HEAD` and compare to check if the graph is stale.
- Run `graphify update .` after code changes (no API cost).

## Community Hubs (Navigation)
- Package
- FlightBooking
- AddTravellerIsSelf
- .Confirm
- RoomsBooking
- Room
- TravelApi.Data
- http
- learning4.csproj
- AppDbContext
- AppDbContextModelSnapshot.cs
- Migration
- learning4.Migrations
- AddPackages
- AddCustomers
- AddCustomerDetails
- MergeTravellerIntoCustomer
- .LoginAsync
- AddAuthFieldsToCustomer
- .IsCurrentCustomer

## God Nodes (most connected - your core abstractions)
1. `FlightBooking` - 20 edges
2. `TravelApi.Data` - 17 edges
3. `learning4.Migrations` - 17 edges
4. `TravelApi.Entities` - 16 edges
5. `AppDbContext` - 15 edges
6. `TravelApi.Services` - 15 edges
7. `Room` - 13 edges
8. `RoomsBooking` - 13 edges
9. `TravelApi.Enums` - 12 edges
10. `Package` - 11 edges

## Surprising Connections (you probably didn't know these)
- `ConfirmBookingController` --references--> `IFlightBooking`  [EXTRACTED]
  Controllers/ConfirmBookingController.cs → Services/FlightBookingService.cs
- `AppDbContext` --references--> `FlightBooking`  [EXTRACTED]
  Data/AppDbContext.cs → Entities/FlightBooking.cs
- `AppDbContext` --references--> `Package`  [EXTRACTED]
  Data/AppDbContext.cs → Entities/Package.cs
- `AppDbContext` --references--> `Room`  [EXTRACTED]
  Data/AppDbContext.cs → Entities/Room.cs
- `AppDbContext` --references--> `RoomsBooking`  [EXTRACTED]
  Data/AppDbContext.cs → Entities/RoomsBooking.cs

## Import Cycles
- None detected.

## Communities (24 total, 0 thin omitted)

### Community 0 - "Package"
Cohesion: 0.10
Nodes (24): ControllerBase, Guid, HttpPost, IActionResult, Task, PackageBookingController, Guid, HttpGet (+16 more)

### Community 1 - "FlightBooking"
Cohesion: 0.13
Nodes (22): Guid, HttpGet, HttpPost, IActionResult, Task, FlightBookingController, UpdatePreferencesRequest, DateOnly (+14 more)

### Community 2 - "AddTravellerIsSelf"
Cohesion: 0.29
Nodes (3): MigrationBuilder, ModelBuilder, AddTravellerIsSelf

### Community 3 - ".Confirm"
Cohesion: 0.25
Nodes (6): Guid, HttpPost, IActionResult, Task, ConfirmBookingController, ConfirmBookingRequest

### Community 4 - "RoomsBooking"
Cohesion: 0.15
Nodes (17): Guid, HttpGet, HttpPost, IActionResult, Task, RoomBookingController, DateOnly, Guid (+9 more)

### Community 5 - "Room"
Cohesion: 0.14
Nodes (18): DateOnly, Guid, HttpGet, HttpPost, IActionResult, Task, RoomController, Guid (+10 more)

### Community 6 - "TravelApi.Data"
Cohesion: 0.19
Nodes (7): TravelApi.Dto, TravelApi.Entities, TravelApi.Enums, TravelApi.Data, TravelApi.Controllers, TravelApi.Services, WeatherForecast

### Community 7 - "http"
Cohesion: 0.13
Nodes (15): ASPNETCORE_ENVIRONMENT, applicationUrl, commandName, dotnetRunMessages, environmentVariables, launchBrowser, applicationUrl, commandName (+7 more)

### Community 8 - "learning4.csproj"
Cohesion: 0.22
Nodes (8): net10.0, BCrypt.Net-Next (4.2.0), Microsoft.AspNetCore.Authentication.JwtBearer (10.0.10), Microsoft.AspNetCore.OpenApi (10.0.10), Microsoft.EntityFrameworkCore.Design (10.0.12), Npgsql.EntityFrameworkCore.PostgreSQL (10.0.3), System.IdentityModel.Tokens.Jwt (8.23.0), Microsoft.NET.Sdk.Web

### Community 13 - "AppDbContext"
Cohesion: 0.11
Nodes (21): Guid, HttpGet, HttpPost, IActionResult, Task, CustomerController, ModelBuilder, AppDbContext (+13 more)

### Community 14 - "AppDbContextModelSnapshot.cs"
Cohesion: 0.40
Nodes (3): ModelBuilder, AppDbContextModelSnapshot, ModelSnapshot

### Community 15 - "Migration"
Cohesion: 0.25
Nodes (4): Migration, MigrationBuilder, ModelBuilder, InitialCreate

### Community 16 - "learning4.Migrations"
Cohesion: 0.28
Nodes (4): learning4.Migrations, MigrationBuilder, ModelBuilder, AddRooms

### Community 17 - "AddPackages"
Cohesion: 0.29
Nodes (3): MigrationBuilder, ModelBuilder, AddPackages

### Community 18 - "AddCustomers"
Cohesion: 0.29
Nodes (3): MigrationBuilder, ModelBuilder, AddCustomers

### Community 19 - "AddCustomerDetails"
Cohesion: 0.29
Nodes (3): MigrationBuilder, ModelBuilder, AddCustomerDetails

### Community 20 - "MergeTravellerIntoCustomer"
Cohesion: 0.29
Nodes (3): MigrationBuilder, ModelBuilder, MergeTravellerIntoCustomer

### Community 21 - ".LoginAsync"
Cohesion: 0.19
Nodes (12): HttpPost, IActionResult, Task, AuthController, AuthResponse, LoginRequest, IConfiguration, Error (+4 more)

### Community 22 - "AddAuthFieldsToCustomer"
Cohesion: 0.29
Nodes (3): MigrationBuilder, ModelBuilder, AddAuthFieldsToCustomer

### Community 23 - ".IsCurrentCustomer"
Cohesion: 0.40
Nodes (3): ControllerBase, Guid, ControllerExtensions

## Knowledge Gaps
- **19 isolated node(s):** `ConfirmBookingRequest`, `WeatherForecast`, `$schema`, `commandName`, `dotnetRunMessages` (+14 more)
  These have ≤1 connection - possible missing edges or undocumented components.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `TravelApi.Data` connect `TravelApi.Data` to `AddTravellerIsSelf`, `AppDbContextModelSnapshot.cs`, `Migration`, `learning4.Migrations`, `AddPackages`, `AddCustomers`, `AddCustomerDetails`, `MergeTravellerIntoCustomer`, `AddAuthFieldsToCustomer`?**
  _High betweenness centrality (0.319) - this node is a cross-community bridge._
- **Why does `AppDbContext` connect `AppDbContext` to `Package`, `FlightBooking`, `RoomsBooking`, `Room`, `TravelApi.Data`, `.LoginAsync`?**
  _High betweenness centrality (0.142) - this node is a cross-community bridge._
- **Why does `FlightBooking` connect `FlightBooking` to `Package`, `RoomsBooking`, `AppDbContext`, `TravelApi.Data`?**
  _High betweenness centrality (0.080) - this node is a cross-community bridge._
- **What connects `ConfirmBookingRequest`, `WeatherForecast`, `$schema` to the rest of the system?**
  _19 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `Package` be split into smaller, more focused modules?**
  _Cohesion score 0.1021021021021021 - nodes in this community are weakly interconnected._
- **Should `FlightBooking` be split into smaller, more focused modules?**
  _Cohesion score 0.13086770981507823 - nodes in this community are weakly interconnected._
- **Should `RoomsBooking` be split into smaller, more focused modules?**
  _Cohesion score 0.14855072463768115 - nodes in this community are weakly interconnected._
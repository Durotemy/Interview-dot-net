# Graph Report - travelApp  (2026-09-18)

## Corpus Check
- 52 files · ~10,262 words
- Verdict: corpus is large enough that graph structure adds value.

## Summary
- 227 nodes · 458 edges · 13 communities
- Extraction: 96% EXTRACTED · 4% INFERRED · 0% AMBIGUOUS · INFERRED: 19 edges (avg confidence: 0.8)
- Token cost: 0 input · 0 output

## Graph Freshness
- Built from commit: `a2e4b7f8`
- Run `git rev-parse HEAD` and compare to check if the graph is stale.
- Run `graphify update .` after code changes (no API cost).

## Community Hubs (Navigation)
- Package
- FlightBooking
- learning4.Migrations
- Traveller
- AppDbContext
- Room
- TravelApi.Entities
- http
- learning4.csproj

## God Nodes (most connected - your core abstractions)
1. `FlightBooking` - 18 edges
2. `TravelApi.Entities` - 16 edges
3. `AppDbContext` - 13 edges
4. `Room` - 13 edges
5. `RoomsBooking` - 13 edges
6. `Traveller` - 13 edges
7. `TravelApi.Services` - 12 edges
8. `TravelApi.Data` - 11 edges
9. `Package` - 11 edges
10. `TravelApi.Enums` - 11 edges

## Surprising Connections (you probably didn't know these)
- `AppDbContext` --references--> `FlightBooking`  [EXTRACTED]
  Data/AppDbContext.cs → Entities/FlightBooking.cs
- `AppDbContext` --references--> `Package`  [EXTRACTED]
  Data/AppDbContext.cs → Entities/Package.cs
- `AppDbContext` --references--> `Room`  [EXTRACTED]
  Data/AppDbContext.cs → Entities/Room.cs
- `AppDbContext` --references--> `Traveller`  [EXTRACTED]
  Data/AppDbContext.cs → Entities/Traveller.cs
- `FlightBookingService` --references--> `AppDbContext`  [EXTRACTED]
  Services/FlightBookingService.cs → Data/AppDbContext.cs

## Import Cycles
- None detected.

## Communities (13 total, 0 thin omitted)

### Community 0 - "Package"
Cohesion: 0.10
Nodes (24): ControllerBase, Guid, HttpPost, IActionResult, Task, PackageBookingController, Guid, HttpGet (+16 more)

### Community 1 - "FlightBooking"
Cohesion: 0.15
Nodes (18): Guid, HttpGet, HttpPost, IActionResult, Task, FlightBookingController, UpdatePreferencesRequest, DateOnly (+10 more)

### Community 2 - "learning4.Migrations"
Cohesion: 0.08
Nodes (14): learning4.Migrations, Migration, MigrationBuilder, ModelBuilder, InitialCreate, MigrationBuilder, ModelBuilder, AddRooms (+6 more)

### Community 3 - "Traveller"
Cohesion: 0.16
Nodes (15): Guid, HttpGet, HttpPost, IActionResult, Task, TravellersController, DateOnly, Guid (+7 more)

### Community 4 - "AppDbContext"
Cohesion: 0.13
Nodes (20): Booking, Guid, HttpGet, HttpPost, IActionResult, Task, RoomBookingController, AppDbContext (+12 more)

### Community 5 - "Room"
Cohesion: 0.16
Nodes (14): Guid, HttpGet, HttpPost, IActionResult, Task, RoomController, Guid, Room (+6 more)

### Community 6 - "TravelApi.Entities"
Cohesion: 0.20
Nodes (6): TravelApi.Entities, TravelApi.Enums, TravelApi.Data, TravelApi.Controllers, TravelApi.Services, WeatherForecast

### Community 7 - "http"
Cohesion: 0.13
Nodes (15): ASPNETCORE_ENVIRONMENT, applicationUrl, commandName, dotnetRunMessages, environmentVariables, launchBrowser, applicationUrl, commandName (+7 more)

### Community 8 - "learning4.csproj"
Cohesion: 0.33
Nodes (5): net10.0, Microsoft.AspNetCore.OpenApi (10.0.10), Microsoft.EntityFrameworkCore.Design (10.0.12), Npgsql.EntityFrameworkCore.PostgreSQL (10.0.3), Microsoft.NET.Sdk.Web

## Knowledge Gaps
- **15 isolated node(s):** `WeatherForecast`, `$schema`, `commandName`, `dotnetRunMessages`, `launchBrowser` (+10 more)
  These have ≤1 connection - possible missing edges or undocumented components.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `TravelApi.Data` connect `TravelApi.Entities` to `learning4.Migrations`?**
  _High betweenness centrality (0.216) - this node is a cross-community bridge._
- **Why does `AppDbContext` connect `AppDbContext` to `Package`, `FlightBooking`, `Traveller`, `Room`, `TravelApi.Entities`?**
  _High betweenness centrality (0.132) - this node is a cross-community bridge._
- **Why does `FlightBooking` connect `FlightBooking` to `Package`, `Traveller`, `AppDbContext`, `TravelApi.Entities`?**
  _High betweenness centrality (0.103) - this node is a cross-community bridge._
- **What connects `WeatherForecast`, `$schema`, `commandName` to the rest of the system?**
  _15 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `Package` be split into smaller, more focused modules?**
  _Cohesion score 0.1036036036036036 - nodes in this community are weakly interconnected._
- **Should `FlightBooking` be split into smaller, more focused modules?**
  _Cohesion score 0.14919354838709678 - nodes in this community are weakly interconnected._
- **Should `learning4.Migrations` be split into smaller, more focused modules?**
  _Cohesion score 0.08172043010752689 - nodes in this community are weakly interconnected._
# Graph Report - travelApp  (2026-09-18)

## Corpus Check
- 61 files · ~12,753 words
- Verdict: corpus is large enough that graph structure adds value.

## Summary
- 287 nodes · 572 edges · 15 communities
- Extraction: 96% EXTRACTED · 4% INFERRED · 0% AMBIGUOUS · INFERRED: 22 edges (avg confidence: 0.8)
- Token cost: 0 input · 0 output

## Graph Freshness
- Built from commit: `0a0716b8`
- Run `git rev-parse HEAD` and compare to check if the graph is stale.
- Run `graphify update .` after code changes (no API cost).

## Community Hubs (Navigation)
- Package
- FlightBooking
- learning4.Migrations
- Traveller
- RoomsBooking
- AppDbContext
- TravelApi.Entities
- http
- learning4.csproj
- Customer
- AppDbContextModelSnapshot.cs

## God Nodes (most connected - your core abstractions)
1. `TravelApi.Entities` - 19 edges
2. `FlightBooking` - 18 edges
3. `TravelApi.Data` - 15 edges
4. `AppDbContext` - 15 edges
5. `Traveller` - 15 edges
6. `TravelApi.Services` - 14 edges
7. `Room` - 13 edges
8. `RoomsBooking` - 13 edges
9. `learning4.Migrations` - 13 edges
10. `TravelApi.Enums` - 12 edges

## Surprising Connections (you probably didn't know these)
- `AppDbContext` --references--> `Customer`  [EXTRACTED]
  Data/AppDbContext.cs → Entities/Customer.cs
- `AppDbContext` --references--> `FlightBooking`  [EXTRACTED]
  Data/AppDbContext.cs → Entities/FlightBooking.cs
- `AppDbContext` --references--> `Package`  [EXTRACTED]
  Data/AppDbContext.cs → Entities/Package.cs
- `AppDbContext` --references--> `RoomsBooking`  [EXTRACTED]
  Data/AppDbContext.cs → Entities/RoomsBooking.cs
- `AppDbContext` --references--> `Traveller`  [EXTRACTED]
  Data/AppDbContext.cs → Entities/Traveller.cs

## Import Cycles
- None detected.

## Communities (15 total, 0 thin omitted)

### Community 0 - "Package"
Cohesion: 0.11
Nodes (22): ControllerBase, Guid, HttpPost, IActionResult, Task, PackageBookingController, Guid, HttpGet (+14 more)

### Community 1 - "FlightBooking"
Cohesion: 0.12
Nodes (24): Guid, HttpGet, HttpPost, IActionResult, Task, FlightBookingController, UpdatePreferencesRequest, DateOnly (+16 more)

### Community 2 - "learning4.Migrations"
Cohesion: 0.05
Nodes (20): learning4.Migrations, Migration, MigrationBuilder, ModelBuilder, InitialCreate, MigrationBuilder, ModelBuilder, AddRooms (+12 more)

### Community 3 - "Traveller"
Cohesion: 0.16
Nodes (16): Guid, HttpGet, HttpPost, IActionResult, Task, TravellersController, DateOnly, Guid (+8 more)

### Community 4 - "RoomsBooking"
Cohesion: 0.15
Nodes (17): Guid, HttpGet, HttpPost, IActionResult, Task, RoomBookingController, DateOnly, Guid (+9 more)

### Community 5 - "AppDbContext"
Cohesion: 0.12
Nodes (21): DateOnly, Guid, HttpGet, HttpPost, IActionResult, Task, RoomController, AppDbContext (+13 more)

### Community 6 - "TravelApi.Entities"
Cohesion: 0.20
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

## Knowledge Gaps
- **15 isolated node(s):** `WeatherForecast`, `$schema`, `commandName`, `dotnetRunMessages`, `launchBrowser` (+10 more)
  These have ≤1 connection - possible missing edges or undocumented components.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `TravelApi.Data` connect `TravelApi.Entities` to `learning4.Migrations`, `AppDbContextModelSnapshot.cs`?**
  _High betweenness centrality (0.286) - this node is a cross-community bridge._
- **Why does `AppDbContext` connect `AppDbContext` to `Package`, `FlightBooking`, `Traveller`, `RoomsBooking`, `TravelApi.Entities`, `Customer`?**
  _High betweenness centrality (0.162) - this node is a cross-community bridge._
- **Why does `Traveller` connect `Traveller` to `FlightBooking`, `Customer`, `RoomsBooking`, `AppDbContext`?**
  _High betweenness centrality (0.094) - this node is a cross-community bridge._
- **What connects `WeatherForecast`, `$schema`, `commandName` to the rest of the system?**
  _15 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `Package` be split into smaller, more focused modules?**
  _Cohesion score 0.10756302521008404 - nodes in this community are weakly interconnected._
- **Should `FlightBooking` be split into smaller, more focused modules?**
  _Cohesion score 0.11806543385490754 - nodes in this community are weakly interconnected._
- **Should `learning4.Migrations` be split into smaller, more focused modules?**
  _Cohesion score 0.053877551020408164 - nodes in this community are weakly interconnected._
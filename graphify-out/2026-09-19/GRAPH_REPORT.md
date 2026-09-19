# Graph Report - travelApp  (2026-09-18)

## Corpus Check
- 60 files · ~12,792 words
- Verdict: corpus is large enough that graph structure adds value.

## Summary
- 263 nodes · 502 edges · 21 communities (20 shown, 1 thin omitted)
- Extraction: 96% EXTRACTED · 4% INFERRED · 0% AMBIGUOUS · INFERRED: 18 edges (avg confidence: 0.8)
- Token cost: 0 input · 0 output

## Graph Freshness
- Built from commit: `0a0716b8`
- Run `git rev-parse HEAD` and compare to check if the graph is stale.
- Run `graphify update .` after code changes (no API cost).

## Community Hubs (Navigation)
- Package
- FlightBooking
- Migration
- TravelApi.Data
- RoomsBooking
- Room
- TravelApi.Entities
- http
- learning4.csproj
- AppDbContext
- AppDbContextModelSnapshot
- InitialCreate
- AddRooms
- AddPackages
- AddCustomers
- AddCustomerDetails
- MergeTravellerIntoCustomer

## God Nodes (most connected - your core abstractions)
1. `FlightBooking` - 18 edges
2. `TravelApi.Entities` - 16 edges
3. `TravelApi.Data` - 15 edges
4. `learning4.Migrations` - 15 edges
5. `AppDbContext` - 13 edges
6. `Room` - 13 edges
7. `RoomsBooking` - 13 edges
8. `TravelApi.Services` - 12 edges
9. `TravelApi.Enums` - 12 edges
10. `Customer` - 11 edges

## Surprising Connections (you probably didn't know these)
- `Room` --references--> `RoomCategory`  [EXTRACTED]
  Entities/Room.cs → enum/RoomCategory.cs
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

## Communities (21 total, 1 thin omitted)

### Community 0 - "Package"
Cohesion: 0.10
Nodes (24): ControllerBase, Guid, HttpPost, IActionResult, Task, PackageBookingController, Guid, HttpGet (+16 more)

### Community 1 - "FlightBooking"
Cohesion: 0.14
Nodes (22): Guid, HttpGet, HttpPost, IActionResult, Task, FlightBookingController, UpdatePreferencesRequest, DateOnly (+14 more)

### Community 2 - "Migration"
Cohesion: 0.29
Nodes (4): Migration, MigrationBuilder, ModelBuilder, AddTravellerIsSelf

### Community 4 - "RoomsBooking"
Cohesion: 0.16
Nodes (16): Guid, HttpGet, HttpPost, IActionResult, Task, RoomBookingController, DateOnly, Guid (+8 more)

### Community 5 - "Room"
Cohesion: 0.14
Nodes (17): DateOnly, Guid, HttpGet, HttpPost, IActionResult, Task, RoomController, Guid (+9 more)

### Community 6 - "TravelApi.Entities"
Cohesion: 0.16
Nodes (7): TravelApi.Entities, TravelApi.Enums, TravelApi.Controllers, TravelApi.Services, RequestStatus, RoomCategory, WeatherForecast

### Community 7 - "http"
Cohesion: 0.13
Nodes (15): ASPNETCORE_ENVIRONMENT, applicationUrl, commandName, dotnetRunMessages, environmentVariables, launchBrowser, applicationUrl, commandName (+7 more)

### Community 8 - "learning4.csproj"
Cohesion: 0.33
Nodes (5): net10.0, Microsoft.AspNetCore.OpenApi (10.0.10), Microsoft.EntityFrameworkCore.Design (10.0.12), Npgsql.EntityFrameworkCore.PostgreSQL (10.0.3), Microsoft.NET.Sdk.Web

### Community 13 - "AppDbContext"
Cohesion: 0.12
Nodes (17): Guid, HttpGet, HttpPost, IActionResult, Task, CustomerController, AppDbContext, DbContext (+9 more)

### Community 14 - "AppDbContextModelSnapshot"
Cohesion: 0.50
Nodes (3): ModelBuilder, AppDbContextModelSnapshot, ModelSnapshot

### Community 15 - "InitialCreate"
Cohesion: 0.33
Nodes (3): MigrationBuilder, ModelBuilder, InitialCreate

### Community 16 - "AddRooms"
Cohesion: 0.33
Nodes (3): MigrationBuilder, ModelBuilder, AddRooms

### Community 17 - "AddPackages"
Cohesion: 0.33
Nodes (3): MigrationBuilder, ModelBuilder, AddPackages

### Community 18 - "AddCustomers"
Cohesion: 0.33
Nodes (3): MigrationBuilder, ModelBuilder, AddCustomers

### Community 19 - "AddCustomerDetails"
Cohesion: 0.33
Nodes (3): MigrationBuilder, ModelBuilder, AddCustomerDetails

### Community 20 - "MergeTravellerIntoCustomer"
Cohesion: 0.33
Nodes (3): MigrationBuilder, ModelBuilder, MergeTravellerIntoCustomer

## Knowledge Gaps
- **15 isolated node(s):** `WeatherForecast`, `$schema`, `commandName`, `dotnetRunMessages`, `launchBrowser` (+10 more)
  These have ≤1 connection - possible missing edges or undocumented components.
- **1 thin communities (<3 nodes) omitted from report** — run `graphify query` to explore isolated nodes.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `TravelApi.Data` connect `TravelApi.Data` to `Package`, `RoomsBooking`, `Room`, `TravelApi.Entities`, `AppDbContext`?**
  _High betweenness centrality (0.329) - this node is a cross-community bridge._
- **Why does `AppDbContext` connect `AppDbContext` to `Package`, `FlightBooking`, `RoomsBooking`, `Room`?**
  _High betweenness centrality (0.127) - this node is a cross-community bridge._
- **Why does `FlightBooking` connect `FlightBooking` to `Package`, `AppDbContext`, `TravelApi.Entities`?**
  _High betweenness centrality (0.082) - this node is a cross-community bridge._
- **What connects `WeatherForecast`, `$schema`, `commandName` to the rest of the system?**
  _15 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `Package` be split into smaller, more focused modules?**
  _Cohesion score 0.10241820768136557 - nodes in this community are weakly interconnected._
- **Should `FlightBooking` be split into smaller, more focused modules?**
  _Cohesion score 0.13903743315508021 - nodes in this community are weakly interconnected._
- **Should `Room` be split into smaller, more focused modules?**
  _Cohesion score 0.13763440860215054 - nodes in this community are weakly interconnected._
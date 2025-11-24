# Hotel Management System

## How to update database when there are changes in the models?

```bash
# Use Package Manager Console in Visual Studio
# First, remove existing migrations if any
Remove-Migration -Force
# Then, add a new migration
Add-Migration [name] -OutputDir Data/Migrations
# Finally, update the database
Update-Database
```
Layered/N-Tier Architecture combining:
*   Repository + Unit of Work for data access
*   Service Layer for business logic
*	Dependency Injection for loose coupling
- Illustration of relationships:

```text
UI Layer (Forms) 
    ↓
Service Layer (Business Logic)
    ↓
Unit of Work (Transaction Coordination)
    ↓
Repository Layer (Data Access Abstraction)
    ↓
DbContext (Entity Framework Core)
    ↓
Database
```

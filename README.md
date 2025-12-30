# 🏨 Hotel Management System

> A comprehensive desktop application for managing hotel operations, built with .NET 10 and Windows Forms.

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-12.0-239120?logo=c-sharp)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![PostgreSQL](https://img.shields.io/badge/PostgreSQL-16-4169E1?logo=postgresql)](https://www.postgresql.org/)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

## 📋 Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Tech Stack](#tech-stack)
- [Architecture](#architecture)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Configuration](#configuration)
- [Usage](#usage)
- [Project Structure](#project-structure)
- [Database Schema](#database-schema)
- [Contributing](#contributing)
- [License](#license)

## 🎯 Overview

This Hotel Management System is a full-featured desktop application designed to streamline hotel operations. Built for the IT008 course at the University of Information Technology (UIT-VNUHCM), it provides comprehensive tools for managing rooms, bookings, invoices, payments, and reporting — all through a modern Windows Forms interface.

## ✨ Features

### 🔐 Authentication & Authorization

- Secure user authentication with BCrypt password hashing
- Role-based access control (Admin, Staff, Customer)
- User profile management
- System tray integration for quick access

### 🛏️ Room Management

- Room type configuration (Standard, Deluxe, Suite, etc.)
- Real-time room availability tracking
- Room status management (Available, Occupied, Maintenance)
- Bulk operations and CSV export

### 📅 Booking System

- Intuitive booking creation and management
- Customer information handling
- Multiple room booking support
- Booking history and search functionality
- Print booking details

### 💰 Invoice & Payment Processing

- Automated invoice generation from bookings
- Flexible payment tracking (Cash, Credit Card, Bank Transfer)
- Payment status management (Pending, Paid)
- Payment merging capabilities
- Mark invoices as paid/pending

### 📊 Reports & Analytics

- Revenue reports with customizable date ranges
- Booking statistics and trends
- Room occupancy analytics
- Visual charts and graphs using System.Windows.Forms.DataVisualization
- CSV export for all reports

### 🎛️ System Parameters

- Configurable system settings
- Business rules management
- Maximum guest capacity settings
- Pricing rules and surcharges

### 🔍 Advanced Features

- Global search and filtering with Gridify
- Soft delete implementation for data integrity
- Pagination support for large datasets
- Responsive form layouts
- FontAwesome Sharp icons for modern UI
- Print functionality for bookings and invoices

## 🛠️ Tech Stack

### Core Technologies

- **.NET 10.0** - Modern framework with improved performance
- **C# 12** - Latest language features with nullable reference types
- **Windows Forms** - Rich desktop UI framework

### Database

- **PostgreSQL** - Production-grade relational database
- **Entity Framework Core 10** - ORM with code-first migrations
- **Npgsql** - PostgreSQL data provider

### Key Libraries

- **AutoMapper 16.0** - Object-to-object mapping
- **BCrypt.Net-Next 4.0** - Secure password hashing
- **Gridify 2.17** - Advanced filtering and sorting
- **FontAwesome.Sharp 6.6** - Modern iconography
- **Bogus 35.6** - Realistic data seeding
- **Microsoft.Extensions.Hosting** - Dependency injection and configuration

## 🏗️ Architecture

The application follows clean architecture principles with clear separation of concerns:

```
┌─────────────────────────────────────────────┐
│           Presentation Layer                │
│  (WinForms UI, User Controls, Forms)        │
└──────────────────┬──────────────────────────┘
                   │
┌──────────────────▼──────────────────────────┐
│           Application Layer                 │
│    (Services, DTOs, AutoMapper)             │
└──────────────────┬──────────────────────────┘
                   │
┌──────────────────▼──────────────────────────┐
│            Domain Layer                     │
│   (Models, Entities, Interfaces)            │
└──────────────────┬──────────────────────────┘
                   │
┌──────────────────▼──────────────────────────┐
│        Infrastructure Layer                 │
│  (EF Core, Repositories, DbContext)         │
└─────────────────────────────────────────────┘
```

### Key Patterns

- **Repository Pattern** - Data access abstraction
- **Unit of Work** - Transaction management
- **Dependency Injection** - Loose coupling and testability
- **Service Layer** - Business logic encapsulation
- **DTO Pattern** - Data transfer optimization
- **Soft Delete** - Data integrity and audit trail

## 🚀 Getting Started

### Prerequisites

Before you begin, ensure you have the following installed:

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) or later
- [PostgreSQL 16+](https://www.postgresql.org/download/)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (or VS Code with C# extensions)
- Windows 10/11 (for Windows Forms)

### Installation

1. **Clone the repository**

   ```bash
   git clone https://github.com/yourusername/HotelManagementIt008.git
   cd HotelManagementIt008
   ```

2. **Restore NuGet packages**

   ```bash
   dotnet restore
   ```

3. **Set up the database**

   Create a PostgreSQL database:

   ```sql
   CREATE DATABASE hotel_management;
   ```

4. **Configure connection string**

   Create or update `appsettings.json` in the project root:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Database=hotel_management;Username=your_username;Password=your_password"
     },
     "Security": {
       "SaltKey": "secret_key"
     }
   }
   ```

5. **Apply migrations**

   ```bash
   dotnet ef database update
   ```

6. **Build and run**
   ```bash
   dotnet run
   ```

### Configuration

The application uses `appsettings.json` for configuration. Key settings include:

- **ConnectionStrings**: Database connection configuration
- **Logging**: Application logging levels
- **Application Settings**: Custom business logic parameters

> ⚠️ **Note**: `appsettings.json` is gitignored to protect sensitive data. Use `appsettings.example.json` as a template.

### Default Credentials

The database seeder creates default users for testing:

```
Admin Account:
Username: admin
Password: admin123

Staff Account:
Username: staff
Password: staff123
```

> 🔒 **Security**: Change these credentials in production!

## 💡 Usage

### First Run

1. Launch the application — it will automatically seed the database with sample data
2. Log in using the default admin credentials
3. The system tray icon allows quick access to the main dashboard

### Main Features

#### Dashboard

- Overview of current bookings, revenue, and occupancy
- Quick stats and visualizations
- Navigation to all major modules

#### Managing Rooms

1. Navigate to **Room Management**
2. Add/Edit room types with pricing
3. Create rooms and assign them to types
4. Track room status and availability

#### Creating Bookings

1. Go to **Booking Management**
2. Click **New Booking**
3. Select customer (existing or create new)
4. Choose room and dates
5. System automatically generates invoice

#### Processing Payments

1. Navigate to **Invoice Management** or **Payment Management**
2. Select pending invoice
3. Record payment with method (Cash/Card/Transfer)
4. Mark as paid or process partial payments
5. Merge multiple payments if needed

#### Generating Reports

1. Open **Reports** module
2. Select report type (Revenue, Bookings, Rooms)
3. Set date range and filters
4. View charts and export to CSV

## 📁 Project Structure

```
HotelManagementIt008/
├── Configurations/          # Application configuration classes
├── Core/                    # Core utilities and base classes
├── Data/                    # Database context and migrations
│   ├── HotelManagementDbContext.cs
│   ├── Migrations/
│   └── Seeders/
├── Dtos/                    # Data Transfer Objects
│   ├── Requests/
│   └── Responses/
├── Extensions/              # Extension methods
├── Forms/                   # Windows Forms UI
│   ├── LoginForm.cs
│   ├── MainDashboardForm.cs
│   ├── BookingManagementForm.cs
│   ├── RoomManagementForm.cs
│   ├── InvoiceManagementForm.cs
│   ├── PaymentManagementForm.cs
│   └── ReportsForm.cs
├── Helpers/                 # Helper utilities
├── Mapping/                 # AutoMapper profiles
├── Models/                  # Domain entities
│   ├── User.cs
│   ├── Room.cs
│   ├── Booking.cs
│   ├── Invoice.cs
│   └── Payment.cs
├── Repositories/            # Data access layer
├── Resources/               # Images, icons, assets
├── Services/                # Business logic layer
│   ├── Interfaces/
│   └── Implementations/
├── Types/                   # Enums and type definitions
├── UserControls/            # Reusable UI components
├── Program.cs               # Application entry point
├── GlobalUsings.cs          # Global using directives
└── appsettings.json         # Configuration (gitignored)
```

## 🗄️ Database Schema

### Core Entities

- **Users** - System users with authentication
- **Profiles** - User profile information
- **Roles** - Access control roles
- **UserTypes** - Customer, Staff, Admin types
- **RoomTypes** - Room categories and pricing
- **Rooms** - Physical rooms in the hotel
- **Bookings** - Customer reservations
- **BookingDetails** - Detailed booking information
- **Invoices** - Billing records
- **Payments** - Payment transactions
- **Params** - System configuration parameters

### Key Relationships

```
User ──1:1── Profile
User ──1:N── Booking (as Booker)
User ──1:N── BookingDetails (as Customer)
Room ──1:N── Booking
RoomType ──1:N── Room
Booking ──1:1── Invoice
Invoice ──N:1── Payment
```

### Soft Delete Implementation

All entities implement soft delete through the `ISoftDeletable` interface:

- Records are never physically deleted
- `DeletedAt` timestamp marks deleted records
- Global query filters automatically exclude soft-deleted entities
- Maintains data integrity and audit trail

## 🤝 Contributing

We welcome contributions! Here's how you can help:

1. **Fork the repository**
2. **Create a feature branch**
   ```bash
   git checkout -b feature/amazing-feature
   ```
3. **Commit your changes**
   ```bash
   git commit -m 'Add some amazing feature'
   ```
4. **Push to the branch**
   ```bash
   git push origin feature/amazing-feature
   ```
5. **Open a Pull Request**

### Development Guidelines

- Follow C# coding conventions and use meaningful names
- Write clean, self-documenting code
- Add XML documentation for public APIs
- Ensure all migrations are reversible
- Test thoroughly before submitting PR
- Keep commits atomic and descriptive

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## � Team

This project was developed by a collaborative team of students from the University of Information Technology – VNUHCM (UIT) for the IT008 - Windows Programming course.

### Team Members

**Bao Le (lvb2104)**

- GitHub: [@lvb2104](https://github.com/lvb2104)
- Role: Project Lead & Developer

**Nguyễn Xuân Nhật Minh**

- GitHub: [@minh10m](https://github.com/minh10m)
- Role: Developer

**Huynh Hiep**

- GitHub: [@HuynhHiep213](https://github.com/HuynhHiep213)
- Role: Developer

## 🙏 Acknowledgments

- **UIT-VNUHCM** for the IT008 course framework
- **Microsoft** for .NET and Entity Framework Core
- **Npgsql** team for PostgreSQL integration
- All open-source library contributors

---

<div align="center">

**Built with ❤️ using .NET and Windows Forms**

If you find this project helpful, consider giving it a ⭐!

</div>

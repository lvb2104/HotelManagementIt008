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

## **Main forms (only for admin and staff):**

1. **LoginForm**
2. **UsersForm**
3. **RolesForm** (CRUD ROLE) – assign/revoke role cho staff (only admin)
4. **UserTypesForm** (CRUD USER_TYPE)

---
6. **BookingsForm** (list + add/update/cancel)
7. **CheckInDialog** (from booking)
8. **CheckOutDialog** (Lock bill, generate invoice)
9. **BookingParticipantsDialog** (add/delete users – table BOOKING_PARTICIPANT)
10. **InvoicesForm** (view/print invoice; linking booking)
11. **ParamsForm** (CRUD PARAMS – configure DayRent, Surcharge,…)

> DoD: kiểm tra phòng trống theo ngày, không cho overlap; tổng tiền = (đơn giá x đêm) ± surcharge; trạng thái booking/invoice cập nhật đúng.
---
12. **RoomTypesForm** (CRUD ROOM_TYPE)
13. **RoomsForm** (CRUD ROOM) – trạng thái: Available/Occupied/Cleaning…
14. **PaymentsForm** (ghi nhận thanh toán cho INVOICE; hoàn tiền nếu cần)
15. **RevenueMonthlyReportForm** (MONTH_REVENUE – tổng doanh thu theo tháng)
16. **RevenueByRoomTypeReportForm** (MONTH_REVENUE_DETAIL – doanh thu theo loại phòng)
17. **DashboardForm** (màn chính/MDI: ô trạng thái phòng, doanh thu tháng, booking hôm nay)

> DoD: export PDF/Excel; filter theo tháng/phòng; Payment liên kết Invoice, validate số tiền.

---

Layered/N-Tier Architecture combining:
*   Repository + Unit of Work for data access
*   Service Layer for business logic
*	MVP (planned) for UI separation
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

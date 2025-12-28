using HotelManagementIt008.Core;
using HotelManagementIt008.Dtos.Responses;
using HotelManagementIt008.Repositories.Interfaces;
using HotelManagementIt008.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementIt008.Services.Implementations
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<RevenueStatsDto>>> GetRevenueStatsAsync(DateTime start, DateTime end)
        {
            try
            {
                var query = _unitOfWork.InvoiceRepository.GetAllQueryable()
                    .Where(i => i.CreatedAt >= start && i.CreatedAt <= end && i.DeletedAt == null);

                var grouped = await query
                    .GroupBy(i => i.CreatedAt.Date)
                    .Select(g => new RevenueStatsDto
                    {
                        Date = g.Key,
                        Revenue = g.Sum(x => x.TotalPrice)
                    })
                    .OrderBy(x => x.Date)
                    .ToListAsync();

                return Result<List<RevenueStatsDto>>.Success(grouped);
            }
            catch (Exception ex)
            {
                return Result<List<RevenueStatsDto>>.Failure($"Error getting revenue stats: {ex.Message}");
            }
        }

        public async Task<Result<List<RoomPopularityDto>>> GetRoomTypePopularityAsync(DateTime start, DateTime end)
        {
            try
            {
                var bookings = _unitOfWork.BookingRepository.GetAllQueryable()
                    .Include(b => b.Room)
                    .ThenInclude(r => r.RoomType)
                    .Where(b => b.CreatedAt >= start && b.CreatedAt <= end && b.DeletedAt == null);

                var grouped = await bookings
                    .GroupBy(b => b.Room.RoomType.Name)
                    .Select(g => new RoomPopularityDto
                    {
                        RoomType = g.Key,
                        BookingCount = g.Count()
                    })
                    .OrderByDescending(x => x.BookingCount)
                    .ToListAsync();

                return Result<List<RoomPopularityDto>>.Success(grouped);
            }
            catch (Exception ex)
            {
                return Result<List<RoomPopularityDto>>.Failure($"Error getting room popularity: {ex.Message}");
            }
        }

        public async Task<Result<ReportSummaryDto>> GetSummaryStatsAsync(DateTime start, DateTime end)
        {
            try
            {
                var bookingsCount = await _unitOfWork.BookingRepository.GetAllQueryable()
                    .CountAsync(b => b.CreatedAt >= start && b.CreatedAt <= end && b.DeletedAt == null);

                var revenue = await _unitOfWork.InvoiceRepository.GetAllQueryable()
                    .Where(i => i.CreatedAt >= start && i.CreatedAt <= end && i.DeletedAt == null)
                    .SumAsync(i => i.TotalPrice);

                var customersCount = await _unitOfWork.BookingRepository.GetAllQueryable()
                    .Where(b => b.CreatedAt >= start && b.CreatedAt <= end && b.DeletedAt == null)
                    .Select(b => b.BookerId)
                    .Distinct()
                    .CountAsync();

                var occupancy = await CalculateOccupancyRateAsync(start, end);

                var summary = new ReportSummaryDto
                {
                    TotalBookings = bookingsCount,
                    TotalRevenue = revenue,
                    TotalCustomers = customersCount,
                    OccupancyRate = occupancy
                };

                return Result<ReportSummaryDto>.Success(summary);
            }
            catch (Exception ex)
            {
                return Result<ReportSummaryDto>.Failure($"Error getting summary stats: {ex.Message}");
            }
        }

        private async Task<decimal> CalculateOccupancyRateAsync(DateTime start, DateTime end)
        {
            var totalRooms = await _unitOfWork.RoomRepository.GetAllQueryable()
                .CountAsync(r => r.DeletedAt == null);
            
            if (totalRooms == 0) return 0;

            var daysInRange = (end - start).TotalDays;
            if (daysInRange <= 0) daysInRange = 1;

            var totalCapacity = totalRooms * (decimal)daysInRange;

            // Find overlapping bookings
            var bookings = await _unitOfWork.BookingRepository.GetAllQueryable()
                .Where(b => b.CheckInDate < end && b.CheckOutDate > start && b.DeletedAt == null)
                .Select(b => new { b.CheckInDate, b.CheckOutDate })
                .ToListAsync();

            decimal totalOccupiedDays = 0;

            foreach (var b in bookings)
            {
                var overlapStart = b.CheckInDate > start ? b.CheckInDate : start;
                var overlapEnd = b.CheckOutDate < end ? b.CheckOutDate : end;

                var overlap = (overlapEnd - overlapStart).TotalDays;
                if (overlap > 0)
                {
                    totalOccupiedDays += (decimal)overlap;
                }
            }

            if (totalCapacity == 0) return 0;

            return (totalOccupiedDays / totalCapacity) * 100;
        }
    }
}

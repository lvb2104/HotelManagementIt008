using HotelManagementIt008.Core;
using HotelManagementIt008.Dtos.Responses;

namespace HotelManagementIt008.Services.Interfaces
{
    public interface IReportService
    {
        Task<Result<ReportSummaryDto>> GetSummaryStatsAsync(DateTime start, DateTime end);
        Task<Result<List<RevenueStatsDto>>> GetRevenueStatsAsync(DateTime start, DateTime end);
        Task<Result<List<RoomPopularityDto>>> GetRoomTypePopularityAsync(DateTime start, DateTime end);
    }
}

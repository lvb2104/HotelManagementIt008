namespace HotelManagementIt008.Repositories.Interfaces
{
    // Define methods specific to Booking entity
    public interface IBookingRepository : IRepository<Booking>
    {
        Task<IEnumerable<Booking>> FindOverlappingBookingsAsync(Guid roomId, DateTime checkIn, DateTime checkOut, Guid? excludeBookingId = null);
        Task<IEnumerable<Booking>> FindUserOverlappingBookingsAsync(Guid userId, DateTime checkIn, DateTime checkOut, Guid? excludeBookingId = null);
    }
}

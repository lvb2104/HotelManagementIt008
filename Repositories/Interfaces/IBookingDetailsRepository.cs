namespace HotelManagementIt008.Repositories.Interfaces
{
    // Define methods specific to BookingDetails entity
    public interface IBookingDetailsRepository : IRepository<BookingDetails>
    {
        Task<IEnumerable<BookingDetails>> GetByBookingIdAsync(Guid bookingId);
    }
}

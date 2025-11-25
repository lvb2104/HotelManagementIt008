namespace HotelManagementIt008.Repositories.Implementations
{
    public class BookingDetailsRepository : Repository<BookingDetails>, IBookingDetailsRepository
    {
        public BookingDetailsRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

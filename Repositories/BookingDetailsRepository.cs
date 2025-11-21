namespace HotelManagementIt008.Repositories
{
    public class BookingDetailsRepository : Repository<BookingDetails>, IBookingDetailsRepository
    {
        public BookingDetailsRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

namespace HotelManagementIt008.Repositories
{
    public class BookingDetailsRepository : GenericRepository<BookingDetails>, IBookingDetailsRepository
    {
        public BookingDetailsRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

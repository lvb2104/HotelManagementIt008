namespace HotelManagementIt008.Repositories
{
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        public BookingRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

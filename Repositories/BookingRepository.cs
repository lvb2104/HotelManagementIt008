namespace HotelManagementIt008.Repositories
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        public BookingRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

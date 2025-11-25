namespace HotelManagementIt008.Repositories.Implementations
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        public BookingRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

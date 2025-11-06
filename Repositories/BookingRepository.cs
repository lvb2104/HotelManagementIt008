namespace HotelManagementIt008.Repositories
{
    internal class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        public BookingRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

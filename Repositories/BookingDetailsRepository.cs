namespace HotelManagementIt008.Repositories
{
    internal class BookingDetailsRepository : GenericRepository<BookingDetails>, IBookingDetailsRepository
    {
        public BookingDetailsRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

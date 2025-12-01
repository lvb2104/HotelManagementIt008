using Microsoft.EntityFrameworkCore;

namespace HotelManagementIt008.Repositories.Implementations
{
    public class BookingDetailsRepository : Repository<BookingDetails>, IBookingDetailsRepository
    {
        public BookingDetailsRepository(HotelManagementDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<BookingDetails>> GetByBookingIdAsync(Guid bookingId)
        {
            return await GetAllQueryable()
                .Include(bd => bd.User)
                    .ThenInclude(u => u.Profile)
                .Include(bd => bd.User)
                    .ThenInclude(u => u.UserType)
                .Where(bd => bd.BookingId == bookingId)
                .ToListAsync();
        }
    }
}

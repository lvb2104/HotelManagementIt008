using Microsoft.EntityFrameworkCore;

namespace HotelManagementIt008.Repositories.Implementations
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        public BookingRepository(HotelManagementDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Booking>> FindOverlappingBookingsAsync(Guid roomId, DateTime checkIn, DateTime checkOut, Guid? excludeBookingId = null)
        {
            var query = GetAllQueryable()
                .Where(b => b.RoomId == roomId &&
                            b.CheckInDate < checkOut &&
                            b.CheckOutDate > checkIn);

            if (excludeBookingId.HasValue)
            {
                query = query.Where(b => b.Id != excludeBookingId.Value);
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Booking>> FindUserOverlappingBookingsAsync(Guid userId, DateTime checkIn, DateTime checkOut, Guid? excludeBookingId = null)
        {
            // We need to check if the user is a participant in any booking that overlaps
            // Since Booking has BookingDetails -> User, we check BookingDetails
            var query = Context.Bookings
                .Include(b => b.BookingDetails)
                .Where(b => b.BookingDetails.Any(bd => bd.UserId == userId) &&
                            b.CheckInDate < checkOut &&
                            b.CheckOutDate > checkIn);

            if (excludeBookingId.HasValue)
            {
                query = query.Where(b => b.Id != excludeBookingId.Value);
            }

            return await query.ToListAsync();
        }
    }
}

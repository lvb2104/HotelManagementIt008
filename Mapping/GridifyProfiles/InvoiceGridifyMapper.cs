using Gridify;

namespace HotelManagementIt008.Mapping.GridifyProfiles
{
    public class InvoiceGridifyMapper : GridifyMapper<Invoice>
    {
        public InvoiceGridifyMapper()
        {
            AddMap("bookingId", i => i.BookingId)
                .AddMap("totalAmount", i => i.TotalPrice)
                .AddMap("status", i => i.Status)
                .AddMap("createdAt", i => i.CreatedAt)
                .AddMap("updatedAt", i => i.UpdatedAt)
                .AddMap("bookerEmail", i => i.Booking.Booker.Email);
        }
    }
}

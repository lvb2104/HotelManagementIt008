using Gridify;

namespace HotelManagementIt008.Mapping.GridifyProfiles
{
    public class BookingGridifyMapper : GridifyMapper<Booking>
    {
        public BookingGridifyMapper()
        {
            AddMap("roomNumber", b => b.Room.RoomNumber)
                .AddMap("checkInDate", b => b.CheckInDate.Date)
                .AddMap("checkOutDate", b => b.CheckOutDate.Date)
                .AddMap("totalPrice", b => b.TotalPrice)
                .AddMap("bookerEmail", b => b.Booker.Email)
                .AddMap("createdAt", b => b.CreatedAt.Date);
        }
    }
}

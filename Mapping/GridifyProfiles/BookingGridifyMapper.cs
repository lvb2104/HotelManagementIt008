using Gridify;

namespace HotelManagementIt008.Mapping.GridifyProfiles
{
    public class BookingGridifyMapper : GridifyMapper<Booking>
    {
        public BookingGridifyMapper()
        {
            AddMap("roomNumber", b => b.Room.RoomNumber)
                .AddMap("checkInDate", b => b.CheckInDate)
                .AddMap("checkOutDate", b => b.CheckOutDate)
                .AddMap("totalPrice", b => b.TotalPrice)
                .AddMap("bookerUsername", b => b.Booker.Username)
                .AddMap("createdAt", b => b.CreatedAt);
        }
    }
}

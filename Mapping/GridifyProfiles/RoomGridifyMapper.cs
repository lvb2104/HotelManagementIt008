using Gridify;

namespace HotelManagementIt008.Mapping.GridifyProfiles
{
    public class RoomGridifyMapper : GridifyMapper<Room>
    {
        public RoomGridifyMapper()
        {
            AddMap("room", r => r.RoomNumber)
                .AddMap("type", r => r.RoomType.Name)
                .AddMap("price", r => r.RoomType.PricePerNight)
                .AddMap("status", r => r.Status)
                .AddMap("note", r => r.Note);
        }
    }
}

using Gridify;

namespace HotelManagementIt008.Mapping.GridifyProfiles
{
    public class RoomTypeGridifyMapper : GridifyMapper<RoomType>
    {
        public RoomTypeGridifyMapper()
        {
            AddMap("name", rt => rt.Name)
                .AddMap("description", rt => rt.Description)
                .AddMap("price", rt => rt.PricePerNight);
        }
    }
}

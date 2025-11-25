namespace HotelManagementIt008.Repositories.Implementations
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

namespace HotelManagementIt008.Repositories
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

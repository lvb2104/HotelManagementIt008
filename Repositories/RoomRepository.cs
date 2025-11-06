namespace HotelManagementIt008.Repositories
{
    public class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        public RoomRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

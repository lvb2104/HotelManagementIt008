namespace HotelManagementIt008.Repositories
{
    internal class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        public RoomRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

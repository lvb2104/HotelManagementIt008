namespace HotelManagementIt008.Repositories
{
    public class RoomTypeRepository : GenericRepository<RoomType>, IRoomTypeRepository
    {
        public RoomTypeRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

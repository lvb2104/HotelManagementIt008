namespace HotelManagementIt008.Repositories
{
    public class RoomTypeRepository : Repository<RoomType>, IRoomTypeRepository
    {
        public RoomTypeRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

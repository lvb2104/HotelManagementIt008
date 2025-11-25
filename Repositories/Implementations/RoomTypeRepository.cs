namespace HotelManagementIt008.Repositories.Implementations
{
    public class RoomTypeRepository : Repository<RoomType>, IRoomTypeRepository
    {
        public RoomTypeRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

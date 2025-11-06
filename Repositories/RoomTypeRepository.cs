namespace HotelManagementIt008.Repositories
{
    internal class RoomTypeRepository : GenericRepository<RoomType>, IRoomTypeRepository
    {
        public RoomTypeRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

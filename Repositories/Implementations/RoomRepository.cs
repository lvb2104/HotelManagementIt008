using Microsoft.EntityFrameworkCore;

namespace HotelManagementIt008.Repositories.Implementations
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(HotelManagementDbContext context) : base(context)
        {

        }

        // Override to filter out soft-deleted rooms
        public override IQueryable<Room> GetAllQueryable()
        {
            return Context.Rooms
                .Where(r => r.DeletedAt == null)
                .AsNoTracking();
        }
    }
}

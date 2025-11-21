namespace HotelManagementIt008.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

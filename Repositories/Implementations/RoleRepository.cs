namespace HotelManagementIt008.Repositories.Implementations
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

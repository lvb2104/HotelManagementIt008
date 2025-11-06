namespace HotelManagementIt008.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

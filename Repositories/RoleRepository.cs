namespace HotelManagementIt008.Repositories
{
    internal class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

namespace HotelManagementIt008.Repositories
{
    internal class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

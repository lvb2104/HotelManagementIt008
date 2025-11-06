namespace HotelManagementIt008.Repositories
{
    internal class UserTypeRepository : GenericRepository<UserType>, IUserTypeRepository
    {
        public UserTypeRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

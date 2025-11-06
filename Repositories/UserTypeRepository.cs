namespace HotelManagementIt008.Repositories
{
    public class UserTypeRepository : GenericRepository<UserType>, IUserTypeRepository
    {
        public UserTypeRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

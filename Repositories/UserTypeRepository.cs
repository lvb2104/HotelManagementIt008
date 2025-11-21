namespace HotelManagementIt008.Repositories
{
    public class UserTypeRepository : Repository<UserType>, IUserTypeRepository
    {
        public UserTypeRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

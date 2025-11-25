namespace HotelManagementIt008.Repositories.Implementations
{
    public class UserTypeRepository : Repository<UserType>, IUserTypeRepository
    {
        public UserTypeRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

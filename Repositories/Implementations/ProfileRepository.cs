namespace HotelManagementIt008.Repositories.Implementations
{
    public class ProfileRepository : Repository<Profile>, IProfileRepository
    {
        public ProfileRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

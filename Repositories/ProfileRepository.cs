namespace HotelManagementIt008.Repositories
{
    public class ProfileRepository : Repository<Profile>, IProfileRepository
    {
        public ProfileRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

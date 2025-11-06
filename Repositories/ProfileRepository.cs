namespace HotelManagementIt008.Repositories
{
    public class ProfileRepository : GenericRepository<Profile>, IProfileRepository
    {
        public ProfileRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

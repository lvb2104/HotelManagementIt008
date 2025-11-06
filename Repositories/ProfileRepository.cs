namespace HotelManagementIt008.Repositories
{
    internal class ProfileRepository : GenericRepository<Profile>, IProfileRepository
    {
        public ProfileRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

namespace HotelManagementIt008.Repositories.Implementations
{
    public class ProfileRepository : Repository<Profile>, IProfileRepository
    {
        //   public string IdentityCardNumber { get; set; } = string.Empty; // add this line
        public ProfileRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

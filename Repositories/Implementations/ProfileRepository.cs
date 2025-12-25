namespace HotelManagementIt008.Repositories.Implementations
{
    public class ProfileRepository : Repository<Profile>, IProfileRepository
    {
        //   public string IdentityCardNumber { get; set; } = string.Empty; // thêm dòng này
        public ProfileRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

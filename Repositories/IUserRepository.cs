namespace HotelManagementIt008.Repositories
{
    // Define methods specific to User entity
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> FindUserByUsernameAsync(string username);
        Task<bool> ExistsAsync(string username);
    }
}

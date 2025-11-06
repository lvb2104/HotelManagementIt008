namespace HotelManagementIt008.Interfaces.Repositories
{
    // Define methods specific to User entity
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> FindUserByUsernameAsync(string username);
        Task<bool> ExistsAsync(string username);
    }
}

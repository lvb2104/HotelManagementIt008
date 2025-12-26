namespace HotelManagementIt008.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task DeleteAsync(Guid id);
        Task<User?> FindUserByUsernameAsync(string username);
    }
}

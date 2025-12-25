namespace HotelManagementIt008.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<User> GetAllQueryable();
        //  Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(Guid id);
        //  Task<User?> GetByUsernameAsync(string username);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(Guid id); // <-- thêm dòng này
        //Task<int> CountAsync(Expression<Func<User, bool>> predicate);
        Task<User?> FindUserByUsernameAsync(string username);
    }
}

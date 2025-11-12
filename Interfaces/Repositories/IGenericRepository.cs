namespace HotelManagementIt008.Interfaces.Repositories
{
    // Define generic methods for all repositories
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T entity);
        IQueryable<T> GetAllQueryable();
        Task<ICollection<T>> GetAllAsync();
        Task<T?> GetByIdAsync(string id);
        Task<bool> RemoveAsync(string id);
        Task RemoveAsync(T entity);
        Task UpdateAsync(T entity);
    }
}

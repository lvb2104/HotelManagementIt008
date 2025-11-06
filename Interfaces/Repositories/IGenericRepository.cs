namespace HotelManagementIt008.Interfaces.Repositories
{
    // Define generic methods for all repositories
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task<ICollection<T>> GetAllAsync(); // TODO: Paging
        Task<T?> GetByIdAsync(string id);
        Task<bool> TryDeleteAsync(string id);
        Task TryDeleteAsync(T entity);
        Task UpdateAsync(T entity);
    }
}

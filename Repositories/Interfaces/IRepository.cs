using System.Linq.Expressions;

namespace HotelManagementIt008.Repositories.Interfaces
{
    // Define generic methods for all repositories
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        IQueryable<T> GetAllQueryable();
        Task<ICollection<T>> GetAllAsync();
        Task<T?> GetByIdAsync(string id);
        Task<bool> RemoveAsync(string id);
        Task RemoveAsync(T entity);
        Task UpdateAsync(T entity);
        int Count(Expression<Func<T, bool>>? predicate = null);
    }
}

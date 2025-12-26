using System.Linq.Expressions;

namespace HotelManagementIt008.Repositories.Interfaces
{
    // Define generic methods for all repositories
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        IQueryable<T> GetAllQueryable();
        Task<ICollection<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task<bool> RemoveAsync(Guid id);
        Task RemoveAsync(T entity);
        Task UpdateAsync(T entity);
        int Count(Expression<Func<T, bool>>? predicate = null); // Need to use Expression because delegate Func only works with in-memory collections, and Expression allows for database translation, if not use it, we will lose the ability to filter data in the database
    }
}

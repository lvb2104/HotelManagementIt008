
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

namespace HotelManagementIt008.Repositories.Implementations
{
    // Implement generic methods for all repositories
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly HotelManagementDbContext Context;
        private readonly DbSet<T> _dbSet;

        public Repository(HotelManagementDbContext context)
        {
            Context = context;
            _dbSet = Context.Set<T>();
        }

        // Use "virtual" keyword to allow overriding in derived classes (UserRepository, RoomRepository, etc.)
        public virtual async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual IQueryable<T> GetAllQueryable()
        {
            return _dbSet.AsNoTracking();
        }

        public virtual async Task<ICollection<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(string id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<bool> RemoveAsync(string id)
        {
            var entityToDelete = await _dbSet.FindAsync(id);
            if (entityToDelete is null)
            {
                return false;
            }

            await RemoveAsync(entityToDelete);
            return true;
        }

        public virtual async Task RemoveAsync(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual async Task UpdateAsync(T entity)
        {
            // Mark the entire entity as modified
            _dbSet.Update(entity);
        }

        public int Count(Expression<Func<T, bool>>? predicate = null)
        {
            if (predicate is null)
            {
                return _dbSet.Count();
            }
            else
            {
                return _dbSet.Count(predicate);
            }
        }
    }
}

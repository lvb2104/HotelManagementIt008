using Microsoft.EntityFrameworkCore;

namespace HotelManagementIt008.Repositories
{
    // Implement generic methods for all repositories
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly HotelManagementDbContext Context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(HotelManagementDbContext context)
        {
            Context = context;
            _dbSet = Context.Set<T>();
        }

        // Use "virtual" keyword to allow overriding in derived classes (UserRepository, RoomRepository, etc.)
        public virtual async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual async Task<ICollection<T>> GetAllAsync() // TODO: Paging
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(string id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<bool> TryDeleteAsync(string id)
        {
            var entityToDelete = await _dbSet.FindAsync(id);
            if (entityToDelete is null)
            {
                return false;
            }

            await TryDeleteAsync(entityToDelete);
            return true;
        }

        public virtual async Task TryDeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual async Task UpdateAsync(T entity)
        {
            // Mark the entire entity as modified
            _dbSet.Update(entity);
        }
    }
}

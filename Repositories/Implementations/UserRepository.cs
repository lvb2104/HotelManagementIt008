using Microsoft.EntityFrameworkCore;

namespace HotelManagementIt008.Repositories.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(HotelManagementDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Trả về tất cả users dưới dạng IQueryable kèm navigation properties
        /// </summary>
        public new IQueryable<User> GetAllQueryable()
        {
            return Context.Users
                .Include(u => u.Profile)
                .Include(u => u.Role)
                .Include(u => u.UserType)
                .Where(u => u.DeletedAt == null)
                .AsQueryable();
        }


        /// <summary>
        /// Kiểm tra user tồn tại theo username (chỉ user chưa xóa)
        /// </summary>
        public async Task<bool> ExistsAsync(string username)
        {
            return await Context.Users
                .AsNoTracking()
                .AnyAsync(u => u.Username == username && u.DeletedAt == null);
        }

        /// <summary>
        /// Tìm user theo username kèm navigation properties
        /// </summary>
        public async Task<User?> FindUserByUsernameAsync(string username)
        {
            return await Context.Users
                .AsNoTracking()
                .Include(u => u.Profile)
                .Include(u => u.Role)
                .Include(u => u.UserType)
                .FirstOrDefaultAsync(u => u.Username == username && u.DeletedAt == null);
        }
        public async Task DeleteAsync(Guid id)
        {
            var user = await GetByIdAsync(id);
            if (user != null)
            {
                Context.Users.Remove(user);
                await Context.SaveChangesAsync();
            }
        }
        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await Context.Users.FirstOrDefaultAsync(u => u.Id == id && u.DeletedAt == null);
        }

    }
}

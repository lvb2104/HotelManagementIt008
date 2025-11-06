
using Microsoft.EntityFrameworkCore;

namespace HotelManagementIt008.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(HotelManagementDbContext context) : base(context)
        {
        }

        public async Task<bool> ExistsAsync(string username)
        {
            return await Context.Users
                .AsNoTracking()
                .AnyAsync(u => u.Username == username && u.DeletedAt == null);
        }

        public async Task<User?> FindUserByUsernameAsync(string username)
        {
            return await Context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Username == username && u.DeletedAt == null);
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace HotelManagementIt008.Repositories.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(HotelManagementDbContext context) : base(context)
        {
        }

        public override IQueryable<User> GetAllQueryable()
        {
            return Context.Users
                .Include(u => u.Profile)
                .Include(u => u.Role)
                .Include(u => u.UserType)
                .AsQueryable();
        }

        public async Task<User?> FindUserByUsernameAsync(string username)
        {
            return await Context.Users
                .AsNoTracking()
                .Include(u => u.Profile)
                .Include(u => u.Role)
                .Include(u => u.UserType)
                .FirstOrDefaultAsync(u => u.Username == username);
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
    }
}

using Microsoft.EntityFrameworkCore;

namespace HotelManagementIt008.Repositories.Implementations
{
    public class ParamsRepository : Repository<Params>, IParamsRepository
    {
        public ParamsRepository(HotelManagementDbContext context) : base(context)
        {

        }

        public async Task<Params?> GetByKeyAsync(string key)
        {
            return await Context.Params.FirstOrDefaultAsync(p => p.Key == key);
        }

        public async Task<IEnumerable<Params>> GetAllOrderedByCreatedAtAsync()
        {
            return await Context.Params
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Params>> GetHistoryOrderedByCreatedAtAsync()
        {
            return await Context.Params
                .IgnoreQueryFilters()
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace HotelManagementIt008.Repositories.Implementations
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(HotelManagementDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Invoice>> GetInvoicesByMonthOrYearAsync(int? year, int? month)
        {
            if (year == null && month == null)
            {
                return await GetAllQueryable().OrderBy(i => i.UpdatedAt).ToListAsync();
            }

            var query = GetAllQueryable();

            if (year.HasValue)
            {
                query = query.Where(i => i.UpdatedAt.Year == year.Value);
            }

            if (month.HasValue)
            {
                query = query.Where(i => i.UpdatedAt.Month == month.Value);

                if (!year.HasValue)
                {
                    var currentYear = DateTime.Now.Year;
                    query = query.Where(i => i.UpdatedAt.Year == currentYear);
                }
            }

            return await query.OrderBy(i => i.UpdatedAt).ToListAsync();
        }
    }
}

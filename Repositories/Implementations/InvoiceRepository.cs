namespace HotelManagementIt008.Repositories.Implementations
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

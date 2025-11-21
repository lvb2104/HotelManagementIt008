namespace HotelManagementIt008.Repositories
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

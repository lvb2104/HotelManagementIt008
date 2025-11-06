namespace HotelManagementIt008.Repositories
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

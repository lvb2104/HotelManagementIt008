namespace HotelManagementIt008.Repositories
{
    internal class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

namespace HotelManagementIt008.Repositories.Interfaces
{
    // Define methods specific to Invoice entity
    public interface IInvoiceRepository : IRepository<Invoice>
    {
        Task<IEnumerable<Invoice>> GetInvoicesByMonthOrYearAsync(int? year, int? month);
    }
}

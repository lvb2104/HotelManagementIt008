namespace HotelManagementIt008.Repositories
{
    internal class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

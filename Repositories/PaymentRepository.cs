namespace HotelManagementIt008.Repositories
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

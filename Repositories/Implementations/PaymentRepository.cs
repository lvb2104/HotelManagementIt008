namespace HotelManagementIt008.Repositories.Implementations
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

namespace HotelManagementIt008.Repositories
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

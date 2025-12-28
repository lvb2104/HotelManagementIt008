using Gridify;

namespace HotelManagementIt008.Mapping.GridifyProfiles
{
    public class PaymentGridifyMapper : GridifyMapper<Payment>
    {
        public PaymentGridifyMapper()
        {
            AddMap("method", p => p.Method)
                .AddMap("amount", p => p.Amount)
                .AddMap("status", p => p.Status)
                .AddMap("createdAt", p => p.CreatedAt)
                .AddMap("updatedAt", p => p.UpdatedAt);
        }
    }
}

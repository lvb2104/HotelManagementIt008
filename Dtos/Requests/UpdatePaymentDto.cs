using System.ComponentModel.DataAnnotations;

namespace HotelManagementIt008.Dtos.Requests
{
    public class UpdatePaymentDto
    {
        public PaymentMethod? Method { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? Amount { get; set; }

        public PaymentStatus? Status { get; set; }
    }
}

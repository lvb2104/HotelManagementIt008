using System.ComponentModel.DataAnnotations;

namespace HotelManagementIt008.Dtos.Requests
{
    public class CreatePaymentDto
    {
        public PaymentMethod Method { get; set; } = PaymentMethod.Cash;

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Amount { get; set; }

        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;
    }
}

using System.ComponentModel.DataAnnotations;

namespace HotelManagementIt008.Dtos.Requests
{
    public class MergePaymentsDto
    {
        [Required]
        public Guid TargetPaymentId { get; set; }

        [Required]
        [MinLength(1)]
        public List<Guid> PaymentIdsToMerge { get; set; } = new();
    }
}

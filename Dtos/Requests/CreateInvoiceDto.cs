using System.ComponentModel.DataAnnotations;
using HotelManagementIt008.Types;

namespace HotelManagementIt008.Dtos.Requests
{
    public class CreateInvoiceDto
    {
        [Required]
        [Range(0, double.MaxValue)]
        public decimal BasePrice { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal TaxPrice { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal TotalPrice { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int DaysStayed { get; set; }

        [Required]
        public Guid BookingId { get; set; }

        [Required]
        public Guid PaymentId { get; set; }
    }
}

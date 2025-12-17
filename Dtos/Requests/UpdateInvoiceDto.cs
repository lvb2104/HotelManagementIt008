using System.ComponentModel.DataAnnotations;
using HotelManagementIt008.Types;

namespace HotelManagementIt008.Dtos.Requests
{
    public class UpdateInvoiceDto
    {
        [Range(0, double.MaxValue)]
        public decimal? BasePrice { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? TaxPrice { get; set; }

        [Range(1, int.MaxValue)]
        public int? DaysStayed { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? TotalPrice { get; set; }

        public InvoiceStatus? Status { get; set; }
    }
}

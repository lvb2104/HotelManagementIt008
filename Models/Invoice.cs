namespace HotelManagementIt008.Models
{
    public class Invoice : ISoftDeletable
    {
        public Guid Id { get; set; }

        public decimal BasePrice { get; set; }

        public decimal TaxPrice { get; set; }

        public decimal TotalPrice { get; set; }

        public int DaysStayed { get; set; }

        public InvoiceStatus Status { get; set; } = InvoiceStatus.Pending;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public Guid BookingId { get; set; }

        public Guid PaymentId { get; set; }

        // -------------- Navigation Properties --------------

        public Booking Booking { get; set; } = null!;

        public Payment Payment { get; set; } = null!;
    }
}

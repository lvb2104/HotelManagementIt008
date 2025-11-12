namespace HotelManagementIt008.Models
{
    public class Payment : ISoftDeletable
    {
        public Guid Id { get; set; }

        public PaymentMethod Method { get; set; } = PaymentMethod.Cash;

        public double Amount { get; set; }

        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        // -------------- Navigation Properties --------------

        public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
}

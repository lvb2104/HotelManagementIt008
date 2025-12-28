namespace HotelManagementIt008.Dtos.Responses
{
    public class PaymentResponseDto
    {
        public Guid Id { get; set; }
        public PaymentMethod Method { get; set; }
        public decimal Amount { get; set; }
        public PaymentStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public List<InvoiceSummaryDto> Invoices { get; set; } = new();
    }

    public class InvoiceSummaryDto
    {
        public Guid Id { get; set; }
        public decimal TotalPrice { get; set; }
        public InvoiceStatus Status { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}

namespace HotelManagementIt008.Models
{
    public interface ISoftDeletable
    {
        DateTime? DeletedAt { get; set; }
    }
}
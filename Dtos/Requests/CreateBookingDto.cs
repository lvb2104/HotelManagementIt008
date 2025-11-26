using System.ComponentModel.DataAnnotations;

namespace HotelManagementIt008.Dtos.Requests
{
    public class CreateBookingDto
    {
        [Required]
        public Guid RoomId { get; set; }

        [Required]
        public List<CreateParticipantDto> Participants { get; set; } = new List<CreateParticipantDto>();

        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }
    }
}

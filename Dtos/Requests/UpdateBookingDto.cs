using System.ComponentModel.DataAnnotations;

namespace HotelManagementIt008.Dtos.Requests
{
    public class UpdateBookingDto
    {
        public Guid? RoomId { get; set; }

        public List<CreateParticipantDto>? Participants { get; set; }

        public DateTime? CheckInDate { get; set; }

        public DateTime? CheckOutDate { get; set; }
    }
}

using AutoMapper;
using HotelManagementIt008.Dtos.Responses;
using HotelManagementIt008.Models;

namespace HotelManagementIt008.Mapping.AutoMapperProfiles
{
    public class BookingMappingProfile : Profile
    {
        public BookingMappingProfile()
        {
            CreateMap<Booking, BookingResponseDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.Booker))
                .ForMember(dest => dest.Participants, opt => opt.MapFrom(src => src.BookingDetails.Select(bd => bd.User)));

            CreateMap<User, UserBookingResponseDto>();
            CreateMap<User, ParticipantResponseDto>();
            CreateMap<Models.Profile, ProfileResponseDto>();
            CreateMap<UserType, UserTypeResponseDto>();
            CreateMap<Role, RoleResponseDto>();
        }
    }
}

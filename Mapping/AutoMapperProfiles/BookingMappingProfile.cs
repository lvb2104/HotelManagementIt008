using AutoMapper;
using HotelManagementIt008.Dtos.Responses;
using HotelManagementIt008.Models;

namespace HotelManagementIt008.Mapping.AutoMapperProfiles
{
    public class BookingMappingProfile : AutoMapper.Profile
    {
        public BookingMappingProfile()
        {
            CreateMap<Booking, BookingResponseDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.Booker))
                .ForMember(dest => dest.Participants, opt => opt.MapFrom(src => src.BookingDetails.Select(bd => bd.User)));

            CreateMap<User, UserBookingResponseDto>();
            CreateMap<User, ParticipantResponseDto>();
            CreateMap<Models.Profile, ProfileResponseDto>()
                .ForMember(dest => dest.IdentityNumber, opt => opt.MapFrom(src => src.IdentityCardNumber));

            CreateMap<UserType, UserTypeResponseDto>()
                .ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.Type.ToString()));

            CreateMap<Role, RoleResponseDto>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Type.ToString()));
        }
    }
}

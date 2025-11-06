using HotelManagementIt008.Dtos.Responses;

namespace HotelManagementIt008.MappingProfiles
{
    public class UserMappingProfile : AutoMapper.Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, LoginResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Type));
        }
    }
}

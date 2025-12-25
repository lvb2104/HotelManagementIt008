namespace HotelManagementIt008.Mapping.AutoMapperProfiles
{
    public class UserMappingProfile : AutoMapper.Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, LoginResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Type));
            CreateMap<User, UserResponseDto>()
                .ForMember(dest => dest.Role,
                    opt => opt.MapFrom(src => src.Role != null ? src.Role.Type : default))
                .ForMember(dest => dest.UserType,
                    opt => opt.MapFrom(src => src.UserType != null ? src.UserType.Type : default))
                .ForMember(dest => dest.FullName,
                    opt => opt.MapFrom(src => src.Profile != null ? src.Profile.FullName : string.Empty))
                .ForMember(dest => dest.Address,
                    opt => opt.MapFrom(src => src.Profile != null ? src.Profile.Address : string.Empty))
                .ForMember(dest => dest.IdentityNumber,
                    opt => opt.MapFrom(src => src.Profile != null ? src.Profile.IdentityCardNumber : string.Empty));
        }
    }
}

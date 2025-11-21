namespace HotelManagementIt008.Mapping.AutoMapperProfiles
{
    public class RoomTypeMappingProfile : AutoMapper.Profile
    {
        public RoomTypeMappingProfile()
        {
            CreateMap<RoomType, RoomTypeResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.PricePerNight, opt => opt.MapFrom(src => src.PricePerNight));
        }
    }
}

namespace HotelManagementIt008.Mapping.AutoMapperProfiles
{
    public class RoomMappingProfile : AutoMapper.Profile
    {
        public RoomMappingProfile()
        {
            CreateMap<Room, RoomResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.RoomNumber, opt => opt.MapFrom(src => src.RoomNumber))
                .ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.Note))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.RoomType, opt => opt.MapFrom(src => src.RoomType));
        }
    }
}

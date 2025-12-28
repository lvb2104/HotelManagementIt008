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

            CreateMap<CreateRoomTypeDto, RoomType>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Rooms, opt => opt.Ignore());

            CreateMap<UpdateRoomTypeDto, RoomType>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Rooms, opt => opt.Ignore());
        }
    }
}

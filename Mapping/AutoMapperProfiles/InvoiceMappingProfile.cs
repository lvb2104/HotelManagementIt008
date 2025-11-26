using AutoMapper;
using HotelManagementIt008.Dtos.Responses;
using HotelManagementIt008.Models;

namespace HotelManagementIt008.Mapping.AutoMapperProfiles
{
    public class InvoiceMappingProfile : Profile
    {
        public InvoiceMappingProfile()
        {
            CreateMap<Invoice, InvoiceResponseDto>();
            CreateMap<Booking, BookingInvoiceResponseDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.Booker)); // Booking has Booker, not User
            CreateMap<User, UserInvoiceResponseDto>();
        }
    }
}

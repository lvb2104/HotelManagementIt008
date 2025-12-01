using AutoMapper;
using HotelManagementIt008.Dtos.Requests;
using HotelManagementIt008.Dtos.Responses;
using HotelManagementIt008.Models;

namespace HotelManagementIt008.Mapping.AutoMapperProfiles
{
    public class InvoiceMappingProfile : Profile
    {
        public InvoiceMappingProfile()
        {
            CreateMap<Invoice, InvoiceResponseDto>();
            CreateMap<CreateInvoiceDto, Invoice>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TaxPrice, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Booking, opt => opt.Ignore())
                .ForMember(dest => dest.Payment, opt => opt.Ignore());

            CreateMap<Booking, BookingInvoiceResponseDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.Booker)); // Booking has Booker, not User
            CreateMap<User, UserInvoiceResponseDto>();
        }
    }
}

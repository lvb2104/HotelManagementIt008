namespace HotelManagementIt008.Mapping.AutoMapperProfiles
{
    public class PaymentMappingProfile : AutoMapper.Profile
    {
        public PaymentMappingProfile()
        {
            CreateMap<Payment, PaymentResponseDto>()
                .ForMember(dest => dest.Invoices, opt => opt.MapFrom(src => src.Invoices));

            CreateMap<Invoice, InvoiceSummaryDto>()
                .ForMember(dest => dest.RoomNumber, opt => opt.MapFrom(src => src.Booking != null && src.Booking.Room != null ? src.Booking.Room.RoomNumber : "N/A"));

            CreateMap<CreatePaymentDto, Payment>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Invoices, opt => opt.Ignore());
        }
    }
}

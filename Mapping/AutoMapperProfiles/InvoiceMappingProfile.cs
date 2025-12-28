namespace HotelManagementIt008.Mapping.AutoMapperProfiles
{
    public class InvoiceMappingProfile : AutoMapper.Profile
    {
        public InvoiceMappingProfile()
        {
            CreateMap<Invoice, InvoiceResponseDto>();

            // With Dto to entity, we need to ignore some of the fields that are either auto-generated or managed by the system (security reasons)
            CreateMap<CreateInvoiceDto, Invoice>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignore Id when creating a new Invoice to let the database generate it
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore()) // Ignore CreatedAt to let the database set the timestamp
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Booking, opt => opt.Ignore()) // Ignore Booking to set it separately
                .ForMember(dest => dest.Payment, opt => opt.Ignore()); // Ignore Payment to set it separately

            CreateMap<Booking, BookingInvoiceResponseDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.Booker)); // Booking has Booker, not User
            CreateMap<User, UserInvoiceResponseDto>();
            CreateMap<Payment, PaymentInvoiceResponseDto>();
        }
    }
}

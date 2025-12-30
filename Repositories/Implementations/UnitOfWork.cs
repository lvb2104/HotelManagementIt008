namespace HotelManagementIt008.Repositories.Implementations
{
    public class UnitOfWork(HotelManagementDbContext context) : IUnitOfWork
    {
        private readonly HotelManagementDbContext _context = context;
        private IUserRepository? _userRepository;
        private IUserTypeRepository? _userTypeRepository;
        private IRoleRepository? _roleRepository;
        private IProfileRepository? _profileRepository;
        private IRoomRepository? _roomRepository;
        private IRoomTypeRepository? _roomTypeRepository;
        private IBookingRepository? _bookingRepository;
        private IBookingDetailsRepository? _bookingDetailsRepository;
        private IInvoiceRepository? _invoiceRepository;
        private IPaymentRepository? _paymentRepository;
        private IParamsRepository? _paramsRepository;

        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);
        public IUserTypeRepository UserTypeRepository => _userTypeRepository ??= new UserTypeRepository(_context);
        public IRoleRepository RoleRepository => _roleRepository ??= new RoleRepository(_context);
        public IProfileRepository ProfileRepository => _profileRepository ??= new ProfileRepository(_context);
        public IRoomRepository RoomRepository => _roomRepository ??= new RoomRepository(_context);
        public IRoomTypeRepository RoomTypeRepository => _roomTypeRepository ??= new RoomTypeRepository(_context);
        public IBookingRepository BookingRepository => _bookingRepository ??= new BookingRepository(_context);
        public IBookingDetailsRepository BookingDetailsRepository => _bookingDetailsRepository ??= new BookingDetailsRepository(_context);
        public IInvoiceRepository InvoiceRepository => _invoiceRepository ??= new InvoiceRepository(_context);
        public IPaymentRepository PaymentRepository => _paymentRepository ??= new PaymentRepository(_context);
        public IParamsRepository ParamsRepository => _paramsRepository ??= new ParamsRepository(_context);

        public Task<int> SaveAsync() => _context.SaveChangesAsync();

        // Unit of work doesn't create its own context so we don't need to dispose of it, it depends on the DI container, which decides based on the lifetime we registered the UnitOfWork as a service
        // We also don't need to implement IDisposable for IUnitOfWork because GC will take care of it
    }
}

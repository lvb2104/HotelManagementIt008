using HotelManagementIt008.Interfaces;

namespace HotelManagementIt008.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HotelManagementDbContext _context;
        private UserRepository? _userRepository;
        private UserTypeRepository? _userTypeRepository;
        private RoleRepository? _roleRepository;
        private ProfileRepository? _profileRepository;
        private RoomRepository? _roomRepository;
        private RoomTypeRepository? _roomTypeRepository;
        private BookingRepository? _bookingRepository;
        private BookingDetailsRepository? _bookingDetailsRepository;
        private InvoiceRepository? _invoiceRepository;
        private PaymentRepository? _paymentRepository;
        private ParamsRepository? _paramsRepository;

        public UnitOfWork(HotelManagementDbContext context)
        {
            _context = context;
        }
        public IUserRepository UserRepository
        {
            get
            {
                // If _userRepository is null, create a new instance, otherwise return the existing one
                return _userRepository ??= new UserRepository(_context);
            }
        }

        public IUserTypeRepository UserTypeRepository
        {
            get
            {
                return _userTypeRepository ??= new UserTypeRepository(_context);
            }
        }

        public IRoleRepository RoleRepository
        {
            get
            {
                return _roleRepository ??= new RoleRepository(_context);
            }
        }

        public IProfileRepository ProfileRepository
        {
            get
            {
                return _profileRepository ??= new ProfileRepository(_context);
            }
        }

        public IRoomRepository RoomRepository
        {
            get
            {
                return _roomRepository ??= new RoomRepository(_context);
            }
        }

        public IRoomTypeRepository RoomTypeRepository
        {
            get
            {
                return _roomTypeRepository ??= new RoomTypeRepository(_context);
            }
        }

        public IBookingRepository BookingRepository
        {
            get
            {
                return _bookingRepository ??= new BookingRepository(_context);
            }
        }

        public IBookingDetailsRepository BookingDetailsRepository
        {
            get
            {
                return _bookingDetailsRepository ??= new BookingDetailsRepository(_context);
            }
        }

        public IInvoiceRepository InvoiceRepository
        {
            get
            {
                return _invoiceRepository ??= new InvoiceRepository(_context);
            }
        }

        public IPaymentRepository PaymentRepository
        {
            get
            {
                return _paymentRepository ??= new PaymentRepository(_context);
            }
        }

        public IParamsRepository ParamsRepository
        {
            get
            {
                return _paramsRepository ??= new ParamsRepository(_context);
            }
        }

        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }

        // Unit of work doesn't create its own context so we don't need to dispose of it, it depends on the DI container, which decides based on the lifetime we registered the UnitOfWork as a service

    }
}

using HotelManagementIt008.Interfaces.Repositories;

namespace HotelManagementIt008.Interfaces
{
    // Define the Unit of Work interface to encapsulate all repositories
    internal interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IUserTypeRepository UserTypeRepository { get; }
        IRoleRepository RoleRepository { get; }
        IProfileRepository ProfileRepository { get; }
        IRoomRepository RoomRepository { get; }
        IRoomTypeRepository RoomTypeRepository { get; }
        IBookingRepository BookingRepository { get; }
        IBookingDetailsRepository BookingDetailsRepository { get; }
        IInvoiceRepository InvoiceRepository { get; }
        IPaymentRepository PaymentRepository { get; }
        IParamsRepository ParamsRepository { get; }

        Task<int> SaveAsync();
    }
}

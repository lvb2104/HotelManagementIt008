using AutoMapper;

using Gridify;
using Gridify.EntityFramework;

using Microsoft.EntityFrameworkCore;

namespace HotelManagementIt008.Services.Implementations
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IRoomService _roomService;
        private readonly IInvoiceService _invoiceService;
        private readonly IParamService _paramService;
        private readonly IGridifyMapper<Booking> _gridifyMapper;

        public BookingService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IUserService userService,
            IRoomService roomService,
            IInvoiceService invoiceService,
            IParamService paramService,
            IGridifyMapper<Booking> gridifyMapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userService = userService;
            _roomService = roomService;
            _invoiceService = invoiceService;
            _paramService = paramService;
            _gridifyMapper = gridifyMapper;
        }

        public async Task<Result<Paging<BookingResponseDto>>> GetAllBookingsAsync(string userId, GridifyQuery query)
        {
            try
            {
                if (!Guid.TryParse(userId, out var guidUserId))
                    return Result<Paging<BookingResponseDto>>.Failure("Invalid user ID");

                var user = await _unitOfWork.UserRepository.GetByIdAsync(guidUserId);
                if (user == null) return Result<Paging<BookingResponseDto>>.Failure("User not found");

                // Check if admin
                var role = await _unitOfWork.RoleRepository.GetByIdAsync(user.RoleId.ToString());
                bool isAdmin = role?.Type == RoleType.Admin;

                var bookingsQuery = _unitOfWork.BookingRepository.GetAllQueryable()
                    .Include(b => b.Booker)
                        .ThenInclude(u => u.Role)
                    .Include(b => b.Room)
                        .ThenInclude(r => r.RoomType)
                    .Include(b => b.Invoice)
                    .Include(b => b.BookingDetails)
                        .ThenInclude(bd => bd.User)
                            .ThenInclude(u => u.Profile)
                    .Include(b => b.BookingDetails)
                        .ThenInclude(bd => bd.User)
                            .ThenInclude(u => u.UserType)
                    .AsQueryable(); // Cast back to IQueryable for Gridify

                // Apply role-based filtering
                if (!isAdmin)
                {
                    bookingsQuery = bookingsQuery.Where(b => b.BookerId == guidUserId);
                }

                // Apply Gridify filtering, sorting, and paging
                var pagedBookings = await bookingsQuery.GridifyAsync(query, _gridifyMapper);

                // Map to DTOs
                var bookingDtos = _mapper.Map<List<BookingResponseDto>>(pagedBookings.Data);

                return Result<Paging<BookingResponseDto>>.Success(new Paging<BookingResponseDto>
                {
                    Data = bookingDtos,
                    Count = pagedBookings.Count
                });
            }
            catch (Exception ex)
            {
                return Result<Paging<BookingResponseDto>>.Failure($"Error retrieving bookings: {ex.Message}");
            }
        }

        public async Task<Result<Paging<BookingSummaryDto>>> GetBookingSummariesAsync(string userId, GridifyQuery query)
        {
            try
            {
                if (!Guid.TryParse(userId, out var guidUserId))
                    return Result<Paging<BookingSummaryDto>>.Failure("Invalid user ID");

                var user = await _unitOfWork.UserRepository.GetByIdAsync(guidUserId);
                if (user == null) return Result<Paging<BookingSummaryDto>>.Failure("User not found");

                // Check if admin
                var role = await _unitOfWork.RoleRepository.GetByIdAsync(user.RoleId.ToString());
                bool isAdmin = role?.Type == RoleType.Admin;

                var bookingsQuery = _unitOfWork.BookingRepository.GetAllQueryable()
                    .Include(b => b.Room)
                    .Include(b => b.Booker)
                    .AsQueryable();

                // Apply role-based filtering
                if (!isAdmin)
                {
                    bookingsQuery = bookingsQuery.Where(b => b.BookerId == guidUserId);
                }

                // Apply Gridify filtering, sorting, and paging
                var pagedBookings = await bookingsQuery.GridifyAsync(query, _gridifyMapper);

                // Project to DTOs
                var summaryDtos = pagedBookings.Data.Select(b => new BookingSummaryDto
                {
                    Id = b.Id,
                    RoomNumber = b.Room.RoomNumber,
                    CheckInDate = b.CheckInDate,
                    CheckOutDate = b.CheckOutDate,
                    TotalPrice = b.TotalPrice,
                    BookerEmail = b.Booker.Email ?? "",
                    CreatedAt = b.CreatedAt
                }).ToList();

                return Result<Paging<BookingSummaryDto>>.Success(new Paging<BookingSummaryDto>
                {
                    Data = summaryDtos,
                    Count = pagedBookings.Count
                });
            }
            catch (Exception ex)
            {
                return Result<Paging<BookingSummaryDto>>.Failure($"Error retrieving bookings: {ex.Message}");
            }
        }

        public async Task<Result<BookingResponseDto>> GetBookingByIdAsync(string id, string userId)
        {
            try
            {
                if (!Guid.TryParse(userId, out var guidUserId))
                    return Result<BookingResponseDto>.Failure("Invalid user ID");

                var user = await _unitOfWork.UserRepository.GetByIdAsync(guidUserId);
                if (user == null) return Result<BookingResponseDto>.Failure("User not found");

                var booking = await _unitOfWork.BookingRepository.GetAllQueryable()
                    .Include(b => b.Booker)
                    .Include(b => b.Room)
                        .ThenInclude(r => r.RoomType)
                    .Include(b => b.Invoice)
                    .Include(b => b.BookingDetails)
                        .ThenInclude(bd => bd.User)
                            .ThenInclude(u => u.Profile)
                     .Include(b => b.BookingDetails)
                        .ThenInclude(bd => bd.User)
                            .ThenInclude(u => u.UserType)
                    .FirstOrDefaultAsync(b => b.Id.ToString() == id);

                if (booking == null) return Result<BookingResponseDto>.Failure("Booking not found");

                var role = await _unitOfWork.RoleRepository.GetByIdAsync(user.RoleId.ToString());
                bool isAdmin = role?.Type == RoleType.Admin;

                if (Guid.TryParse(userId, out var userGuid))
                {
                    if (booking.BookerId != userGuid && !isAdmin)
                    {
                        return Result<BookingResponseDto>.Failure("This booking does not belong to you.");
                    }
                }
                else if (!isAdmin)
                {
                    return Result<BookingResponseDto>.Failure("Invalid User ID.");
                }

                return Result<BookingResponseDto>.Success(_mapper.Map<BookingResponseDto>(booking));
            }
            catch (Exception ex)
            {
                return Result<BookingResponseDto>.Failure($"Error retrieving booking: {ex.Message}");
            }
        }

        public async Task<Result<BookingResponseDto>> CreateBookingAsync(CreateBookingDto dto, string userId)
        {
            try
            {
                if (!Guid.TryParse(userId, out var guidUserId))
                    return Result<BookingResponseDto>.Failure("Invalid user ID");

                var user = await _unitOfWork.UserRepository.GetByIdAsync(guidUserId);
                if (user == null) return Result<BookingResponseDto>.Failure("User not found");

                var room = await _unitOfWork.RoomRepository.GetAllQueryable()
                    .AsTracking()
                    .Include(r => r.RoomType)
                    .FirstOrDefaultAsync(r => r.Id == dto.RoomId);

                if (room == null) return Result<BookingResponseDto>.Failure("Room not found");
                if (room.Status == RoomStatus.OutOfService) return Result<BookingResponseDto>.Failure("Room is out of service");

                // Convert to UTC for database consistency, but preserve the date
                dto.CheckInDate = DateTime.SpecifyKind(dto.CheckInDate.Date, DateTimeKind.Utc);
                dto.CheckOutDate = DateTime.SpecifyKind(dto.CheckOutDate.Date, DateTimeKind.Utc);

                if (dto.CheckInDate > dto.CheckOutDate) return Result<BookingResponseDto>.Failure("Check-out date must be after check-in date");
                if (dto.CheckInDate.Date < DateTime.UtcNow.Date) return Result<BookingResponseDto>.Failure("Check-in date cannot be in the past"); // TODO: Fix can't choose check-in date is today

                var overlapping = await _unitOfWork.BookingRepository
                    .FindOverlappingBookingsAsync(dto.RoomId, dto.CheckInDate, dto.CheckOutDate);
                if (overlapping.Any()) return Result<BookingResponseDto>.Failure("Room is already booked for these dates");

                var participants = new List<User>();

                if (dto.Participants != null && dto.Participants.Any())
                {
                    foreach (var pDto in dto.Participants)
                    {
                        var participantUser = await _unitOfWork.UserRepository.GetAllQueryable()
                            .AsTracking()
                            .Include(u => u.Profile)
                            .Include(u => u.UserType)
                            .FirstOrDefaultAsync(u => u.Email == pDto.Email);

                        if (participantUser == null)
                        {
                            // Tạo user mặc định
                            var createUserResult = await _userService.CreateDefaultUserAsync(pDto);
                            if (!createUserResult.IsSuccess)
                            {
                                return Result<BookingResponseDto>.Failure(createUserResult.ErrorMessage ?? "Failed to create participant user");
                            }
                            participantUser = createUserResult.Value;
                        }
                        else
                        {
                            // Cập nhật profile
                            if (participantUser.Profile != null)
                            {
                                if (!string.IsNullOrWhiteSpace(pDto.FullName))
                                {
                                    participantUser.Profile.FullName = pDto.FullName;
                                }
                                participantUser.Profile.Address = pDto.Address;
                                participantUser.Profile.IdentityCardNumber = pDto.IdentityNumber;
                                // EF đang tracking nên không cần gọi Update
                            }

                            // Cập nhật UserType nếu khác
                            if (participantUser.UserType?.Type != pDto.UserType)
                            {
                                var newUserType = await _unitOfWork.UserTypeRepository.GetAllQueryable()
                                    .AsTracking()
                                    .FirstOrDefaultAsync(ut => ut.Type == pDto.UserType);
                                if (newUserType != null)
                                {
                                    participantUser.UserTypeId = newUserType.Id;
                                    participantUser.UserType = newUserType;
                                }
                            }
                        }

                        // Check overlap cho participant (không truyền bookingId vì là booking mới)
                        var userOverlapping = await _unitOfWork.BookingRepository
                            .FindUserOverlappingBookingsAsync(participantUser!.Id, dto.CheckInDate, dto.CheckOutDate);
                        if (userOverlapping.Any())
                        {
                            return Result<BookingResponseDto>.Failure($"User {pDto.Email} is already booked for these dates");
                        }

                        // Nhớ add vào list để tính giá & tạo BookingDetails
                        participants.Add(participantUser);
                    }
                }

                // =========================
                // Calculate Price using system params
                // =========================
                var dayRent = (int)Math.Ceiling((dto.CheckOutDate - dto.CheckInDate).TotalDays);
                var basePrice = room.RoomType.PricePerNight * dayRent; // Base price = per night * days only

                var numberOfParticipants = participants.Count;
                var hasForeign = participants.Any(p => p.UserType?.Type == UserTypeType.Foreign);

                // Get system params
                var maxGuestsParam = await _paramService.GetParamByKeyAsync("MAX_GUESTS_PER_ROOM");
                var maxGuests = (maxGuestsParam.IsSuccess && maxGuestsParam.Value != null)
                    ? int.Parse(maxGuestsParam.Value.Value)
                    : 3;

                var foreignSurchargeParam = await _paramService.GetParamByKeyAsync("FOREIGN_SURCHARGE_RATE");
                var foreignSurchargeRate = (foreignSurchargeParam.IsSuccess && foreignSurchargeParam.Value != null)
                    ? decimal.Parse(foreignSurchargeParam.Value.Value)
                    : 1.5m;

                var extraGuestParam = await _paramService.GetParamByKeyAsync("EXTRA_GUEST_SURCHARGE");
                var extraGuestSurcharge = (extraGuestParam.IsSuccess && extraGuestParam.Value != null)
                    ? decimal.Parse(extraGuestParam.Value.Value)
                    : 0.25m;

                var taxRateParam = await _paramService.GetParamByKeyAsync("TAX_RATE");
                var taxRate = (taxRateParam.IsSuccess && taxRateParam.Value != null)
                    ? decimal.Parse(taxRateParam.Value.Value)
                    : 0.10m;

                // Calculate surcharges separately
                var subtotal = basePrice;

                // Apply foreign surcharge if any participant is foreign
                if (hasForeign)
                {
                    subtotal *= foreignSurchargeRate;
                }

                // Apply extra guest surcharge if exceeding max guests
                if (numberOfParticipants > maxGuests)
                {
                    var extraGuests = numberOfParticipants - maxGuests;
                    subtotal += subtotal * extraGuestSurcharge * extraGuests;
                }

                subtotal = Math.Round(subtotal, 2);
                var taxPrice = Math.Round(subtotal * taxRate, 2);
                var totalPrice = subtotal + taxPrice;

                // Create Booking first
                var booking = new Booking
                {
                    RoomId = room.Id,
                    BookerId = user.Id,
                    CheckInDate = dto.CheckInDate,
                    CheckOutDate = dto.CheckOutDate,
                    TotalPrice = totalPrice
                };

                await _unitOfWork.BookingRepository.AddAsync(booking);
                await _unitOfWork.SaveAsync(); // Save to generate Booking Id

                // Create Payment first (required for Invoice)
                var payment = new Payment
                {
                    Id = Guid.NewGuid(),
                    Amount = totalPrice,
                    Method = PaymentMethod.Cash, // Default method, can be updated later
                    Status = PaymentStatus.Pending
                };
                await _unitOfWork.PaymentRepository.AddAsync(payment);
                await _unitOfWork.SaveAsync(); // Save to generate Payment Id

                // Create Invoice (references Booking via BookingId)
                // BasePrice = pure base (per night * days), TaxPrice = tax on subtotal, TotalPrice = subtotal + tax
                var invoiceDto = new CreateInvoiceDto
                {
                    BasePrice = Math.Round(basePrice, 2),
                    TaxPrice = taxPrice,
                    TotalPrice = totalPrice,
                    DaysStayed = dayRent,
                    BookingId = booking.Id,
                    PaymentId = payment.Id
                };

                var invoiceResult = await _invoiceService.CreateInvoiceAsync(invoiceDto);
                if (!invoiceResult.IsSuccess || invoiceResult.Value is null)
                    return Result<BookingResponseDto>.Failure($"Failed to create invoice: {invoiceResult.ErrorMessage}");

                // Add Participants (BookingDetails)
                foreach (var p in participants)
                {
                    var bookingDetail = new BookingDetails
                    {
                        BookingId = booking.Id,
                        UserId = p.Id,
                        Id = Guid.NewGuid()
                    };
                    await _unitOfWork.BookingDetailsRepository.AddAsync(bookingDetail);
                }

                // Update Room Status if check-in is today
                if (dto.CheckInDate.Date == DateTime.UtcNow.Date) // nên dùng Utc cho đồng bộ
                {
                    room.Status = RoomStatus.Occupied;
                    await _unitOfWork.RoomRepository.UpdateAsync(room);
                }

                await _unitOfWork.SaveAsync();

                return await GetBookingByIdAsync(booking.Id.ToString(), userId);
            }
            catch (Exception ex)
            {
                return Result<BookingResponseDto>.Failure($"Error creating booking: {ex.Message}");
            }
        }


        public async Task<Result<BookingResponseDto>> UpdateBookingAsync(string id, UpdateBookingDto dto, string userId)
        {
            try
            {
                if (!Guid.TryParse(userId, out var guidUserId))
                    return Result<BookingResponseDto>.Failure("Invalid user ID");
                var user = await _unitOfWork.UserRepository.GetByIdAsync(guidUserId);
                if (user == null) return Result<BookingResponseDto>.Failure("User not found");

                var booking = await _unitOfWork.BookingRepository.GetAllQueryable()
                    .AsTracking()
                    .Include(b => b.Room)
                        .ThenInclude(r => r.RoomType)
                    .Include(b => b.Invoice)
                    .Include(b => b.BookingDetails)
                        .ThenInclude(bd => bd.User)
                    .FirstOrDefaultAsync(b => b.Id.ToString() == id);

                if (booking == null) return Result<BookingResponseDto>.Failure("Booking not found");

                var role = await _unitOfWork.RoleRepository.GetByIdAsync(user.RoleId.ToString());
                bool isAdmin = role?.Type == RoleType.Admin;

                if (Guid.TryParse(userId, out var userGuid))
                {
                    if (booking.BookerId != userGuid && !isAdmin)
                    {
                        return Result<BookingResponseDto>.Failure("This booking does not belong to you.");
                    }
                }
                else if (!isAdmin)
                {
                    return Result<BookingResponseDto>.Failure("Invalid User ID.");
                }

                // 1. Handle Room and Date Changes - DISABLED (Only participants update allowed)
                // Logic for updating room and dates has been removed as per requirement.


                // 2. Handle Participants
                var participants = new List<User>();
                if (dto.Participants != null)
                {
                    // Remove existing details
                    // Use ToList() to create a copy of the collection to iterate over safely while modifying
                    var existingDetails = booking.BookingDetails.ToList();
                    foreach (var detail in existingDetails)
                    {
                        await _unitOfWork.BookingDetailsRepository.RemoveAsync(detail);
                    }

                    // Add new participants
                    foreach (var pDto in dto.Participants)
                    {
                        var participantUser = await _unitOfWork.UserRepository.GetAllQueryable()
                            .AsTracking()
                            .Include(u => u.Profile)
                            .Include(u => u.UserType)
                            .FirstOrDefaultAsync(u => u.Email == pDto.Email);

                        if (participantUser == null)
                        {
                            var createUserResult = await _userService.CreateDefaultUserAsync(pDto);
                            if (!createUserResult.IsSuccess) return Result<BookingResponseDto>.Failure(createUserResult.ErrorMessage ?? "Failed to create participant");
                            participantUser = createUserResult.Value;
                        }
                        else
                        {
                            // Update existing user profile and type
                            if (participantUser.Profile != null)
                            {
                                if (!string.IsNullOrWhiteSpace(pDto.FullName))
                                {
                                    participantUser.Profile.FullName = pDto.FullName;
                                }
                                participantUser.Profile.Address = pDto.Address;
                                participantUser.Profile.IdentityCardNumber = pDto.IdentityNumber;
                                // await _unitOfWork.ProfileRepository.UpdateAsync(participantUser.Profile); // Removed: Tracked by EF
                            }

                            if (participantUser.UserType?.Type != pDto.UserType)
                            {
                                var newUserType = await _unitOfWork.UserTypeRepository.GetAllQueryable()
                                    .AsTracking()
                                    .FirstOrDefaultAsync(ut => ut.Type == pDto.UserType);
                                if (newUserType != null)
                                {
                                    participantUser.UserTypeId = newUserType.Id;
                                    participantUser.UserType = newUserType;
                                    // await _unitOfWork.UserRepository.UpdateAsync(participantUser); // Removed: Tracked by EF
                                }
                            }

                            // Check overlap for participant
                            var userOverlapping = await _unitOfWork.BookingRepository.FindUserOverlappingBookingsAsync(participantUser.Id, booking.CheckInDate, booking.CheckOutDate, booking.Id);
                            if (userOverlapping.Any()) return Result<BookingResponseDto>.Failure($"User {pDto.Email} is already booked for these dates");
                        }
                        participants.Add(participantUser!);

                        await _unitOfWork.BookingDetailsRepository.AddAsync(new BookingDetails { Id = Guid.NewGuid(), BookingId = booking.Id, UserId = participantUser!.Id });
                    }
                }
                else
                {
                    // Keep existing participants for price calc
                    participants = booking.BookingDetails.Select(bd => bd.User).ToList();
                }

                // 3. Recalculate Price using system params
                var dayRent = (int)Math.Ceiling((booking.CheckOutDate - booking.CheckInDate).TotalDays);
                var basePrice = booking.Room.RoomType.PricePerNight * dayRent; // Base price = per night * days only

                var numberOfParticipants = participants.Count;
                var hasForeign = participants.Any(p => p.UserType?.Type == UserTypeType.Foreign);

                // Get system params
                var maxGuestsParam = await _paramService.GetParamByKeyAsync("MAX_GUESTS_PER_ROOM");
                var maxGuests = (maxGuestsParam.IsSuccess && maxGuestsParam.Value != null)
                    ? int.Parse(maxGuestsParam.Value.Value)
                    : 3;

                var foreignSurchargeParam = await _paramService.GetParamByKeyAsync("FOREIGN_SURCHARGE_RATE");
                var foreignSurchargeRate = (foreignSurchargeParam.IsSuccess && foreignSurchargeParam.Value != null)
                    ? decimal.Parse(foreignSurchargeParam.Value.Value)
                    : 1.5m;

                var extraGuestParam = await _paramService.GetParamByKeyAsync("EXTRA_GUEST_SURCHARGE");
                var extraGuestSurcharge = (extraGuestParam.IsSuccess && extraGuestParam.Value != null)
                    ? decimal.Parse(extraGuestParam.Value.Value)
                    : 0.25m;

                var taxRateParam = await _paramService.GetParamByKeyAsync("TAX_RATE");
                var taxRate = (taxRateParam.IsSuccess && taxRateParam.Value != null)
                    ? decimal.Parse(taxRateParam.Value.Value)
                    : 0.10m;

                // Calculate surcharges separately
                var subtotal = basePrice;

                // Apply foreign surcharge if any participant is foreign
                if (hasForeign)
                {
                    subtotal *= foreignSurchargeRate;
                }

                // Apply extra guest surcharge if exceeding max guests
                if (numberOfParticipants > maxGuests)
                {
                    var extraGuests = numberOfParticipants - maxGuests;
                    subtotal += subtotal * extraGuestSurcharge * extraGuests;
                }

                subtotal = Math.Round(subtotal, 2);
                var taxPrice = Math.Round(subtotal * taxRate, 2);
                var totalPrice = subtotal + taxPrice;

                booking.TotalPrice = totalPrice;

                // 4. Update Invoice
                // BasePrice = pure base (per night * days), TaxPrice = tax on subtotal, TotalPrice = subtotal + tax
                if (booking.Invoice != null)
                {
                    var updateInvoiceDto = new UpdateInvoiceDto
                    {
                        BasePrice = Math.Round(basePrice, 2),
                        TaxPrice = taxPrice,
                        TotalPrice = totalPrice,
                        DaysStayed = dayRent
                    };
                    await _invoiceService.UpdateInvoiceAsync(booking.Invoice.Id.ToString(), updateInvoiceDto);
                }

                await _unitOfWork.SaveAsync();

                return await GetBookingByIdAsync(booking.Id.ToString(), userId);
            }
            catch (Exception ex)
            {
                return Result<BookingResponseDto>.Failure($"Error updating booking: {ex.Message}");
            }
        }

        public async Task<Result<bool>> RemoveBookingAsync(string id, string userId)
        {
            try
            {
                if (!Guid.TryParse(userId, out var guidUserId))
                    return Result<bool>.Failure("Invalid user ID");
                var user = await _unitOfWork.UserRepository.GetByIdAsync(guidUserId);
                if (user == null) return Result<bool>.Failure("User not found");

                var booking = await _unitOfWork.BookingRepository.GetAllQueryable()
                    .Include(b => b.Room)
                    .Include(b => b.Invoice)
                    .FirstOrDefaultAsync(b => b.Id.ToString() == id);

                if (booking == null) return Result<bool>.Failure("Booking not found");

                var role = await _unitOfWork.RoleRepository.GetByIdAsync(user.RoleId.ToString());
                bool isAdmin = role?.Type == RoleType.Admin;

                if (Guid.TryParse(userId, out var userGuid))
                {
                    if (booking.BookerId != userGuid && !isAdmin)
                    {
                        return Result<bool>.Failure("This booking does not belong to you.");
                    }
                }
                else if (!isAdmin)
                {
                    return Result<bool>.Failure("Invalid User ID.");
                }

                // Update Room Status
                if (booking.Room != null)
                {
                    booking.Room.Status = RoomStatus.Available;
                    await _unitOfWork.RoomRepository.UpdateAsync(booking.Room);
                }

                // Soft Remove Booking
                await _unitOfWork.BookingRepository.RemoveAsync(booking);

                // Delete Invoice
                if (booking.Invoice != null)
                {
                    await _invoiceService.DeleteInvoiceAsync(booking.Invoice.Id.ToString());
                }

                await _unitOfWork.SaveAsync();

                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure($"Error removing booking: {ex.Message}");
            }
        }
    }
}

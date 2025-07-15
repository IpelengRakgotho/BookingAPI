using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ResourceBookingSystemAPI.Entities;
using ResourceBookingSystemAPI.Interfaces;
using ResourceBookingSystemAPI.Repositories.BookingManagement.Model;
using ResourceBookingSystemAPI.Wrappers;

namespace ResourceBookingSystemAPI.Repositories.BookingManagement
{
    public class BookingRepository : IBookingRepository
    {

        private readonly IRepository<Booking> _repository;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _db;
        public BookingRepository(IRepository<Booking> repository, IMapper mapper, IApplicationDbContext db)
        {
            _repository = repository;
            _mapper = mapper;
            _db = db;
        }

        public async Task<Response<int>> AddBooking(BookingRequest request)
        {
            try
            {
                if (request == null)
                    return new Response<int>("Booking data is missing.");

                // Check that resource exists
                var resource = await _db.Resource.FirstOrDefaultAsync(r => r.ResourceId == request.ResourceId);
                if (resource == null)
                    return new Response<int>("Resource not found.");

                var booking = new Booking
                {
                    ResourceId = request.ResourceId,
                    StartTime = request.StartTime,
                    EndTime = request.EndTime,
                    BookedBy = request.BookedBy,
                    Purpose = request.Purpose
                };

                await _repository.AddAsync(booking);
                await _repository.SaveChangesAsync();

                return new Response<int>(booking.BookingId, "Booking added successfully.");
            }
            catch (Exception ex)
            {
                // Optionally log ex
                return new Response<int>("Error while adding booking.");
            }
        }
    }
}

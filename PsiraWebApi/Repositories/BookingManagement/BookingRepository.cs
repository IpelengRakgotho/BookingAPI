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

                if (request.StartTime < DateTime.Now)
                    return new Response<int>("Start time cannot be in the past.");

                if (request.EndTime <= request.StartTime)
                    return new Response<int>("End time must be strictly after the start time.");

                var resource = await _db.Resource.FirstOrDefaultAsync(r => r.ResourceId == request.ResourceId);
                if (resource == null)
                    return new Response<int>("Resource not found.");

                var conflictingBooking = await _db.Booking
                    .Where(b => b.ResourceId == request.ResourceId &&
                                b.StartTime < request.EndTime &&
                                b.EndTime > request.StartTime)
                    .FirstOrDefaultAsync();

                if (conflictingBooking != null)
                {
                    return new Response<int>("This resource is already booked during the requested time. Please choose another slot or resource, or adjust your times.");
                }

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
            catch (Exception)
            {
                return new Response<int>("Error while adding booking.");
            }
        }


        public async Task<Response<List<UpcomingBookings>>> GetUpcomingBookings(int resourceId)
        {
            try
            {
                if (resourceId <= 0)
                    return new Response<List<UpcomingBookings>>("Invalid Resource ID.");

                var bookings = await _db.Booking
                    .Where(b => b.ResourceId == resourceId && b.StartTime >= DateTime.Now)
                    .OrderBy(b => b.StartTime)
                    .Select(b => new UpcomingBookings
                    {
                        BookingId = b.BookingId,
                        StartTime = (DateTime)b.StartTime,
                        EndTime = (DateTime)b.EndTime,
                        BookedBy = b.BookedBy,
                        Purpose = b.Purpose
                    })
                    .ToListAsync();

                return new Response<List<UpcomingBookings>>(bookings, "Upcoming bookings fetched.");
            }
            catch (Exception ex)
            {
                return new Response<List<UpcomingBookings>>("Error while fetching bookings.");
            }
        }

        

        public async Task<Response<List<BookingResponse>>> GetAllBookings()
        {
            try
            {
                var bookings = await _db.Booking
                    .Include(b => b.Resource) 
                    .Select(b => new BookingResponse
                    {
                        BookingId = b.BookingId,
                        ResourceId = b.ResourceId,
                        StartTime = (DateTime)b.StartTime,
                        EndTime = (DateTime)b.EndTime,
                        BookedBy = b.BookedBy,
                        Purpose = b.Purpose,
                        ResourceName = b.Resource.Name  
                    })
                    .ToListAsync();

                return new Response<List<BookingResponse>>(bookings, "Bookings retrieved.");
            }
            catch
            {
                return new Response<List<BookingResponse>>("Failed to retrieve bookings.");
            }
        }


        public async Task<Response<BookingResponse>> GetBookingById(int id)
        {
            try
            {
                var booking = await _repository.GetAsync(id);
                if (booking == null)
                {
                    return new Response<BookingResponse>("Resource not found");
                }
                var response = _mapper.Map<BookingResponse>(booking);

                return new Response<BookingResponse>(response);
            }
            catch (Exception ex)
            {
                return new Response<BookingResponse>(ex.Message);
            }
        }

        public async Task<Response<int>> UpdateBooking(UpdateBooking request)
        {
            try
            {
                if (request == null)
                    return new Response<int>("Data is missing.");

                var booking = await _db.Booking.FirstOrDefaultAsync(x => x.BookingId == request.BookingId);
                if (booking == null)
                    return new Response<int>("Booking does not exist.");

                _mapper.Map(request, booking);
              

                _repository.Update(booking);
                await _repository.SaveChangesAsync();

                return new Response<int>(booking.BookingId, "Booking Updated Successfully.");
            }
            catch (Exception ex)
            {
               
                return new Response<int>("Error while updating Booking.");
            }
        }

        public async Task<Response<int>> DeleteBooking(int bookingId)
        {
            try
            {
                if (bookingId <= 0)
                    return new Response<int>("Invalid Booking ID.");

                var deletedResource = await _repository.DeleteAsync(bookingId);
                if (deletedResource == null)
                    return new Response<int>("Booking not found or already deleted.");

                await _repository.SaveChangesAsync();

                return new Response<int>(bookingId, "Booking deleted successfully.");
            }
            catch (Exception ex)
            {

                return new Response<int>("Error while deleting booking.");
            }
        }
    }
}

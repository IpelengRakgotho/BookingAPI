using ResourceBookingSystemAPI.Repositories.BookingManagement.Model;
using ResourceBookingSystemAPI.Wrappers;

namespace ResourceBookingSystemAPI.Interfaces
{
    public interface IBookingRepository
    {
        Task<Response<int>> AddBooking(BookingRequest request);
        Task<Response<List<UpcomingBookings>>> GetUpcomingBookings(int resourceId);
        Task<Response<List<BookingResponse>>> GetAllBookings();
    }
}

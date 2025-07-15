using ResourceBookingSystemAPI.Repositories.BookingManagement.Model;
using ResourceBookingSystemAPI.Repositories.ResourceManagement.Model;
using ResourceBookingSystemAPI.Wrappers;

namespace ResourceBookingSystemAPI.Interfaces
{
    public interface IBookingRepository
    {
        Task<Response<int>> AddBooking(BookingRequest request);
        Task<Response<List<UpcomingBookings>>> GetUpcomingBookings(int resourceId);
        Task<Response<List<BookingResponse>>> GetAllBookings();
        Task<Response<int>> UpdateBooking(UpdateBooking request);
        Task<Response<int>> DeleteBooking(int bookingId);
    }
}

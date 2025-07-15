using ResourceBookingSystemAPI.Repositories.BookingManagement.Model;
using ResourceBookingSystemAPI.Wrappers;

namespace ResourceBookingSystemAPI.Interfaces
{
    public interface IBookingRepository
    {
        Task<Response<int>> AddBooking(BookingRequest request);
    }
}

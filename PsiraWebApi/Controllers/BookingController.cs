using Microsoft.AspNetCore.Mvc;
using ResourceBookingSystemAPI.Interfaces;
using ResourceBookingSystemAPI.Repositories.BookingManagement.Model;
using ResourceBookingSystemAPI.Repositories.ResourceManagement;
using ResourceBookingSystemAPI.Repositories.ResourceManagement.Model;

namespace ResourceBookingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;
        public BookingController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        [HttpPost]
        [Route("AddBookings")]
        public async Task<IActionResult> AddBookings(BookingRequest model)
        {
            var response = await _bookingRepository.AddBooking(model);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}

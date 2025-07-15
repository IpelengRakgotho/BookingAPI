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


        [HttpGet]
        [Route("UpcomingBookings")]
        public async Task<IActionResult> GetUpcomingBookings(int resourceId)
        {
            var response = await _bookingRepository.GetUpcomingBookings(resourceId);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet]
        [Route("GetBookings")]
        public async Task<IActionResult> GetBookings()
        {
            var response = await _bookingRepository.GetAllBookings();
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

    }
}

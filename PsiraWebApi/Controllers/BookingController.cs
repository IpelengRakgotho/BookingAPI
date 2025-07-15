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

        [HttpGet]
        [Route("GetBookingById/{id}")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var response = await _bookingRepository.GetBookingById(id);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(UpdateBooking request)
        {
            var response = await _bookingRepository.UpdateBooking(request);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int bookingId)
        {
            var response = await _bookingRepository.DeleteBooking(bookingId);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}

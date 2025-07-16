using ResourceBookingSystemAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace ResourceBookingSystemAPI.Repositories.BookingManagement.Model
{
    public class BookingRequest
    {
       
        public int ResourceId { get; set; }
        [Required(ErrorMessage = "Start time is required.")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "End time is required.")]
        
        public DateTime EndTime { get; set; }

        [Required(ErrorMessage = "Booked By is required.")]
    
        public string? BookedBy { get; set; }

        [Required(ErrorMessage = "Purpose is required.")]
       
        public string? Purpose { get; set; }
    }
}

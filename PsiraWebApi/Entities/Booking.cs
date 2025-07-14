using System.ComponentModel.DataAnnotations;

namespace ResourceBookingSystemAPI.Entities
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        public int ResourceId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? BookedBy { get; set; }
        public string? Purpose { get; set; }

    }
}

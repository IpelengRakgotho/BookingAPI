using ResourceBookingSystemAPI.Entities;

namespace ResourceBookingSystemAPI.Repositories.BookingManagement.Model
{
    public class BookingRequest
    {
        public int ResourceId { get; set; }

        // Navigation to parent Resource
        public Resource? Resource { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? BookedBy { get; set; }
        public string? Purpose { get; set; }
    }
}

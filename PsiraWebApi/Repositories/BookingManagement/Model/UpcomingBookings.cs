namespace ResourceBookingSystemAPI.Repositories.BookingManagement.Model
{
    public class UpcomingBookings
    {
        public int BookingId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? BookedBy { get; set; }
        public string? Purpose { get; set; }
    }
}

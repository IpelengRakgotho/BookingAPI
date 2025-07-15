namespace ResourceBookingSystemAPI.Repositories.BookingManagement.Model
{
    public class BookingResponse
    {
        public int ResourceId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? BookedBy { get; set; }
        public string? Purpose { get; set; }
    }
}

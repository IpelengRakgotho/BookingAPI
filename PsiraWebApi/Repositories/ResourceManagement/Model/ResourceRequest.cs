namespace ResourceBookingSystemAPI.Repositories.ResourceManagement.Model
{
    public class ResourceRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public int? Capacity { get; set; }
        public bool? IsAvailable { get; set; }
    }
}

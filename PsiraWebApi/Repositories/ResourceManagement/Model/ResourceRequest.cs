using System.ComponentModel.DataAnnotations;

namespace ResourceBookingSystemAPI.Repositories.ResourceManagement.Model
{
    public class ResourceRequest
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Availability is required.")]
        public bool? IsAvailable{ get; set; } 


        [Required(ErrorMessage = "Capacity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Capacity must be at least 1.")]
        public int? Capacity { get; set; }
    }
}

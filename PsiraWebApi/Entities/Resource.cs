using System.ComponentModel.DataAnnotations;

namespace ResourceBookingSystemAPI.Entities
{
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public int? Capacity { get; set; }
        public bool? IsAvailable { get; set; }


    }
}

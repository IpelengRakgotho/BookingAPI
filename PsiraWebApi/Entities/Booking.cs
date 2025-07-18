﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResourceBookingSystemAPI.Entities
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        [ForeignKey("Resource")]
        public int ResourceId { get; set; }

        // Navigation to parent Resource
        public Resource? Resource { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? BookedBy { get; set; }
        public string? Purpose { get; set; }

    }
}

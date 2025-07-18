﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public ICollection<Booking>? Booking { get; set; }
    }
}

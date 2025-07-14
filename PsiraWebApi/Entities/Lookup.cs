using System.ComponentModel.DataAnnotations;

namespace PsiraWebApi.Entities
{
    public class Lookup
    {
        [Key]
        public int LookupId { get; set; }
        public string Name { get; set; } = string.Empty;
       
        public string Type { get; set; } = string.Empty;

    }
}

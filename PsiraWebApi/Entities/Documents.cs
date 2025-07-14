using System.ComponentModel.DataAnnotations;

namespace PsiraWebApi.Entities
{
    public class Documents
    {
        [Key]
        public int DocumentId { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string Filepath { get; set; } = string.Empty;
        public string Extension { get; set; } = string.Empty;
        public int UserId { get; set; } 
        public DateTime Created_at  { get; set; } 
        public DateTime updated_at { get; set; } 
    }
}

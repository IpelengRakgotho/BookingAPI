namespace PsiraWebApi.Repositories.UserManagement.Models
{
    public class DocumentRequest
    {
       
        public string FileName { get; set; } = string.Empty;
        public string Filepath { get; set; } = string.Empty;
        public string Extension { get; set; } = string.Empty;
        public int UserId { get; set; }
        public DateTime Created_at { get; set; }
    }
}

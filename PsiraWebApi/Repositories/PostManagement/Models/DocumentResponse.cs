namespace PsiraWebApi.Repositories.PostManagement.Models
{
    public class DocumentResponse
    {
        public int DocumentId { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string Filepath { get; set; } = string.Empty;
        public string Extension { get; set; } = string.Empty;
        public int UserId { get; set; }
    }
}

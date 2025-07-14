namespace PsiraWebApi.Repositories.PostManagement.Models
{
    public class PostRequest
    {
        public string PostName { get; set; } = string.Empty;
        public string JobDescription { get; set; } = string.Empty;
        public int BusinessUnit { get; set; }
        public string Manager { get; set; } = string.Empty;
        public string ManagerEmail { get; set; } = string.Empty;
        public int NumberOfYearsRequired { get; set; }
        public int QualificationsRequired { get; set; }
        public int DriversLicenseRequired { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public int CreatedBy { get; set; }
    }
}

using PsiraWebApi.Entities;

namespace PsiraWebApi.Repositories.LookupManagement.Models
{
    public class CreatePostLookup
    {
        public List<Lookup>? BusinessUnit { get; set; }
        public List<Lookup>? NumberOfYearsRequired { get; set; }
        public List<Lookup>? QualificationsRequired { get; set; }
        public List<Lookup>? DriversLicenseRequired { get; set; }
    }
}

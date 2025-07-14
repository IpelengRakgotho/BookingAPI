using System.ComponentModel.DataAnnotations;

namespace PsiraWebApi.Repositories.UserManagement.Models
{
    public class UserRequest
    {

        [Required]
        [EmailAddress]
        public string? Username { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 8)]
        public string? Password { get; set; }

        [Required]
        [RegularExpression("^[0-9]{13}$", ErrorMessage = "ID Number must be alphanumeric between 6 and 12 characters.")]
        public string? IDNumber { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Surname { get; set; }

        [Required]
        [Phone]
        public string? CellphoneNumber { get; set; }

        [Required]
        public string? HomeAddress { get; set; }

        [Required]
        public int Province { get; set; } // Assume it's a dropdown combo box in the UI

        public string? ProvinceCode { get; set; }
        public DocumentRequest? Document { get; set; }
    }
}

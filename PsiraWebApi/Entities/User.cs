using System.ComponentModel.DataAnnotations;

namespace PsiraWebApi.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string? Username { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 8)]
        public string? Password { get; set; }

        [Required]
        [RegularExpression("^[A-Z0-9]{6,12}$", ErrorMessage = "ID Number must be alphanumeric between 6 and 12 characters.")]
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
        public int Role { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace PsiraWebApi.Repositories.UserManagement.Models
{
    public class LoginResponse
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? IDNumber { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Surname { get; set; }
        public int Role { get; set; }

        public string RoleName { get; set; }= string.Empty;

        [Required]
        [Phone]
        public string? CellphoneNumber { get; set; }

     
    }
}

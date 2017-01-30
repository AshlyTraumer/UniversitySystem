using System.ComponentModel.DataAnnotations;

namespace UniversitySystem.Models
{
    public class LoginModel
    {
        [Required]

        [StringLength(50, MinimumLength = 3)]
        public string Login { get; set; }

        [Required]
   
        [StringLength(50, MinimumLength = 3)]
        public string Password { get; set; }
    }
}
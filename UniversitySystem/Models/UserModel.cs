using ClassLibrary.Authorization;
using System.ComponentModel.DataAnnotations;

namespace UniversitySystem.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Login { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Password { get; set; }

        public Role Role { get; set; }
    }
}
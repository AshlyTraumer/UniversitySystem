using ClassLibrary.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversitySystem.Models
{
    public class RegisterModel:IValidatableObject
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Login { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [Required]
        public string Password { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [Required]
        [Compare("Password")]
        public string RetypePassword { get; set; }

        [Required]
        public Role Role { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if ((Role == Role.Admin) && (Password.Length > 8))
                yield return new ValidationResult("Длинный пароль", new[] { "Password" });
        }
    }
}
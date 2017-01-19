using System.ComponentModel.DataAnnotations;

namespace UniversitySystem.Models
{
    public class SpecializationModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]        
        public int? FreeCount { get; set; }

        [Required]        
        public int? PayCount { get; set; }
        
        public int DepartamentId { get; set;  }
    }
}
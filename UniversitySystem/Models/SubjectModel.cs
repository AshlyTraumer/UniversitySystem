using System.ComponentModel.DataAnnotations;

namespace UniversitySystem.Models
{
    public class SubjectModel : SpecializationModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]        
        public string Form { get; set; }
    }
}
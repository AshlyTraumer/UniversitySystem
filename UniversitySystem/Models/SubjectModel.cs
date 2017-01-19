using System.ComponentModel.DataAnnotations;

namespace UniversitySystem.Models
{
    public class SubjectModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]        
        public string Form { get; set; }
    }
}
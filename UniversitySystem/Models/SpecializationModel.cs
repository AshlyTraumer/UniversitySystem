using System.ComponentModel.DataAnnotations;

namespace UniversitySystem.Models
{
    public class SpecializationModel : ChangeModelBase
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }
              
        public int FreeCount { get; set; }
             
        public int PayCount { get; set; }
        
        public int DepartamentId { get; set;  }
    }
}
using System.ComponentModel.DataAnnotations;

namespace UniversitySystem.Models
{
    public class ProfessorModel : ChangeModelBase
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        
        public int DepartamentId{ get; set; }
    }
}
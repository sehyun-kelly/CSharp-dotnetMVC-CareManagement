using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareManagement.Models.OM
{
    public class Qualification
    {
        [Key]
        public Guid QualificationId { get; set; } // The Qualification ID

        [Required]
        [ForeignKey("Employee")]
        public Guid EmployeeId { get; set; }

    }
}

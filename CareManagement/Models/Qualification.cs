
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareManagement.Models
{
    public class Qualification
    {
        [Key]
        public Guid QualificationId { get; set; }


        [Required]
        [ForeignKey("Employee")]
        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        [Required]
        [ForeignKey("Service")]
        public Guid ServiceId { get; set; }
        public virtual Service Service { get; set; }

        [Required]
        [StringLength(50)]
        public string QualificationDescription { get; set; }
    }
}

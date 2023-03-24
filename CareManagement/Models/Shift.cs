using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareManagement.Models
{
    public class Shift
    {

        [Key]
       // [Range(0, int.MaxValue)]

        public Guid S_ID { get; set; }

        [Required]
        [ForeignKey("EMPLOYEE")]
        public int EMPLOYEE_ID { get; set; }
        public virtual Employee Employee { get; set; }

        [Required]
        [ForeignKey("EMPLOYEE_MANAGER")]
        public int MANAGER_ID { get; set; }
        public virtual Employee EMPLOYEE_MANAGER { get; set; }

        [Required]
        [Range(0,86399, ErrorMessage = "The start time must be between {1} and {2}")]
        public TimeSpan START_TIME { get; set; }

        [Required]
        [Range(0, 86399, ErrorMessage = "The start time must be between {1} and {2}")]
        public TimeSpan END_TIME { get; set; }


        [Required]
        public Boolean? SICK { get;set }

    }
}

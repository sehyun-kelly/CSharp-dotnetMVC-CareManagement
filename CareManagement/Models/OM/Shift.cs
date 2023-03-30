using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareManagement.Models.OM
{
    public class Shift
    {

        [Key]
        public int ShiftId { get; set; } // The Shift ID

        public Guid S_ID { get; set; }

        [Required]
        public int EmployeeId { get; set; } // The employee working the shift

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; } // Navigation property for the employee

        [Required]
        public int ManagerId { get; set; } // Whoever is responsible for the employee

        [ForeignKey("ManagerId")]
        public Employee Manager { get; set; } // Navigation property for the manager

        [Required]
        public DateTime StartTime { get; set; } // When the shift starts

        [Required]
        public DateTime EndTime { get; set; } // When the shift ends

        [Required]
        public bool Sick { get; set; } // Is true if employee called in sick
    }

}

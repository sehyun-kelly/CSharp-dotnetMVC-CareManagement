using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareManagement.Models
{
    public class Schedule
    {
        [Key]
		public Guid ScheduleId;

		[Key]
		public DateTime ScheduleDate;

		[Required]
		[ForeignKey("Customer")]
		public Guid CustomerId { get; set; } // the actual FK in the table
		public virtual Customer? Customer { get; set; } // reference for the FK

		[Required]
		[ForeignKey("Shift")]
		public Guid ShiftID { get; set; } // the actual FK in the table
		public virtual ICollection<Shift> Shift { get; set; } // reference for the FK
        
		[Required]
		[ForeignKey("Service")]
		public Guid ServiceId { get; set; } // the actual FK in the table
		public virtual Service? Service { get; set; } // reference for the FK
    }
}

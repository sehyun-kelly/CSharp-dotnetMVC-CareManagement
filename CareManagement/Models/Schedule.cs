using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareManagement.Models
{
    public class Schedule
    {
        [Key]
		public Guid scheduleId;

		[Key]
		public DateTime scheduleDate;

		[Required]
		[ForeignKey("Customer")]
		public Guid customerId { get; set; } // the actual FK in the table
		public virtual Customer? Customer { get; set; } // reference for the FK

		[Required]
		[ForeignKey("Shift")]
		public Guid sId { get; set; } // the actual FK in the table
		public virtual ICollection<Shift> Shift { get; set; } // reference for the FK
        
		[Required]
		[ForeignKey("Service")]
		public Guid serviceId { get; set; } // the actual FK in the table
		public virtual Service? Service { get; set; } // reference for the FK
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareManagement.Models
{
	public class Schedule
	{
		[Key]
		public Guid SCHEDULE_ID;

		[Key]
		public DateTime SCHEDULE_DATE;

		[Required]
		[ForeignKey("CUSTOMER")]
		public Guid CUSTOMER_ID { get; set; } // the actual FK in the table
		public virtual Customer? CUSTOMER { get; set; } // reference for the FK

		[Required]
		[ForeignKey("SHIFT")]
		public Guid S_ID { get; set; } // the actual FK in the table
		public virtual ICollection<Shift> SHIFT { get; set; } // reference for the FK

		[Required]
		[ForeignKey("SERVICE")]
		public Guid SERVICE_ID { get; set; } // the actual FK in the table
		public virtual Service? SERVICE { get; set; } // reference for the FK
	}
}

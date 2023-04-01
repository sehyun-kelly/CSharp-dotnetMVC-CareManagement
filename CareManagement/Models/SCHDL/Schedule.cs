using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CareManagement.Models.OM;
using CareManagement.Models.CRM;

namespace CareManagement.Models.SCHDL
{
    public class Schedule
    {
        [Key]
		public Guid ScheduleId { get; set; }

		[Required]
		[Display(Name = "Start Time")]
		public DateTime StartTime { get; set; }

        [Required]
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }

        [Display(Name = "Invoiced")]
        public Boolean IsInvoiced { get; set; } = false;

        [Display(Name = "Repeat")]
        public Boolean IsRepeating { get; set; } = false;

        [Display(Name = "Repeat From")]
        public DateTime? RepeatStartDate { get; set; }

        [Display(Name = "Repeat Until")]
        public DateTime? RepeatEndDate { get; set; }

        [Required]
		[ForeignKey("Renter")]
		public Guid RenterId { get; set; } // the actual FK in the table
		public virtual Renter? Renter { get; set; } // reference for the FK

		[Required]
		[ForeignKey("Shift")]
		public Guid ShiftID { get; set; } // the actual FK in the table
		public virtual Shift? Shift { get; set; } // reference for the FK

		[Required]
		[ForeignKey("Service")]
		public Guid ServiceId { get; set; } // the actual FK in the table
		public virtual Service? Service { get; set; } // reference for the FK
	}
}

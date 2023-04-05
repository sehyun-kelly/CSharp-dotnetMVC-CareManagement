using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CareManagement.Models.CRM;
using CareManagement.Models.OM;

namespace CareManagement.Models.SCHDL
{
	public class Report
	{
        [Key]
        public Guid ReportId { get; set; }

        [Required]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        [Required]
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }

        [Required]
        [ForeignKey("Renter")]
        public Guid RenterId { get; set; } // the actual FK in the table
        public virtual Renter? Renter { get; set; } // reference for the FK

        [Required]
        [ForeignKey("Service")]
        public Guid ServiceId { get; set; } // the actual FK in the table
        public virtual Service? Service { get; set; } // reference for the FK
    }
}


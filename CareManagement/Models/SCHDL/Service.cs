using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareManagement.Models.SCHDL
{
    public class Service
    {
		[Key]
		public Guid ServiceId;

		[Required]
		[ForeignKey("Qualification")]
		public Guid QualificationId { get; set; } // the actual FK in the table
		public virtual Qualification? Qualification { get; set; } // reference for the FK

		[Required]
		[Range(0, double.MaxValue)]  // No negative numbers
		public double Rate;

		[Required]
		[Range(0, double.MaxValue)]
		public double Hours { get; set; }

		[Required]
		[MinLength(5)]
		public string Type { get; set; }
    }
}

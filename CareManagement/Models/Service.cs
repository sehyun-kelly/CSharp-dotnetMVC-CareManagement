using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareManagement.Models
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
		[MinLength(1)]
		public string Type { get; set; } = "None";
	}
}

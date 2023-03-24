using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareManagement.Models
{
	public class Service
	{
		[Key]
		public Guid SERVICE_ID;

		[Required]
		[ForeignKey("QUALIFICATION")]
		public Guid Q_ID { get; set; } // the actual FK in the table
		public virtual Qualification? QUALIFICATION { get; set; } // reference for the FK

		[Required]
		[Range(0, double.MaxValue)]  // No negative numbers
		public double RATE;

		[Required]
		[MinLength(1)]
		public string TYPE { get; set; } = "None";
	}
}

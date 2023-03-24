namespace CareManagement.Models
{
    public class Service
    {
		[Key]
		public Guid serviceId;

		[Required]
		[ForeignKey("Qualification")]
		public Guid qId { get; set; } // the actual FK in the table
		public virtual Qualification? Qualification { get; set; } // reference for the FK

		[Required]
		[Range(0, double.MaxValue)]  // No negative numbers
		public double Rate;

		[Required]
		[MinLength(1)]
		public string Type { get; set; } = "None";
    }
}

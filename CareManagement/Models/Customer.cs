using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareManagement.Models
{
	public class Customer
	{
		[Key]
		public Guid customerId;

		[Required]
		[ForeignKey("Invoice")]
		public int invoiceNo { get; set; } // the actual FK in the table
		public virtual ICollection<Invoice> Invoice { get; set; } // reference for the FK

		[Required]
		[Range(0, int.MaxValue)]  // No negative numbers
		public int rmNumber;

		[Required]
		[Range(0, int.MaxValue)]  // No negative numbers
		public int Age;
	}
}

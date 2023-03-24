using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareManagement.Models
{
	public class Customer
	{
		[Key]
		public Guid CustomerId;

		[Required]
		[ForeignKey("Invoice")]
		public int InvoiceNo { get; set; } // the actual FK in the table
		public virtual ICollection<Invoice> Invoice { get; set; } // reference for the FK

		[Required]
		[Range(0, int.MaxValue)]  // No negative numbers
		public int RmNumber;

		[Required]
		[Range(0, int.MaxValue)]  // No negative numbers
		public int Age;
	}
}

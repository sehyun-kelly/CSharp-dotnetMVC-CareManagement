using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareManagement.Models
{
	public class Customer
	{
		[Key]
		public Guid CUSTOMER_ID;

		[Required]
		[ForeignKey("INVOICE")]
		public int INVOICE_NO { get; set; } // the actual FK in the table
		public virtual ICollection<Invoice> INVOICE { get; set; } // reference for the FK

		[Required]
		[Range(0, int.MaxValue)]  // No negative numbers
		public int RM_NUMBER;

		[Required]
		[Range(0, int.MaxValue)]  // No negative numbers
		public int AGE;
	}
}

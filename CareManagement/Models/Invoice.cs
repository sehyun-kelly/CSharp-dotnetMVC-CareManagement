using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareManagement.Models
{
	public class Invoice
	{
		[Key]
		public Guid InvoiceNumber { get; set; }

		[Required]
		[ForeignKey("Customer")]

		public int CustomerId { get; set; }
		public virtual Customer Customer { get; set; }

		[Required]
		[Range(0.01, double.MaxValue)]
		public double Hours { get; set; }

	}
}

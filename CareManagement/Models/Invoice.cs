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


        /**
         * once an invoice time period is specified we can change the range of dates allowed for an invoice
         */
        [Required]
        [Range(typeof(DateTime), "1/1/2023", "12/31/2023",
        ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime StartDate { get; set; }

        /**
        * once an invoice time period is specified we can change the range of dates allowed for an invoice
        */
        [Required]
        [Range(typeof(DateTime), "1/1/2023", "12/31/2023",
        ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime EndDate { get; set; }

        /**
		 * The total hours of all the services summed together 
		 */

        [Required]
		[Range(0.01, double.MaxValue)]
		public double TotalHours { get; set; }

		/**
		 * the total cost of all the services summed together
		 */
        [Required]
        [Range(0.01, double.MaxValue)]
        public double TotalCost { get; set; }


    }
}

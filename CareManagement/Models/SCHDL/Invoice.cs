using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CareManagement.Models.CRM;

namespace CareManagement.Models.SCHDL
{
	public class Invoice
	{
		[Key]
		public Guid InvoiceNumber { get; set; }


        [Required]
        [ForeignKey("Renter")]
        public Guid RenterId { get; set; } // the actual FK in the table
        public virtual Renter? Renter { get; set; } // reference for the FK


        /**
         * once an invoice time period is specified we can change the range of dates allowed for an invoice
         */
        [Required]
        public DateTime StartDate { get; set; }

        /**
        * once an invoice time period is specified we can change the range of dates allowed for an invoice
        */
        [Required]
        public DateTime EndDate { get; set; }

        /**
		 * The total hours of all the services summed together 
		 */

		[Range(0.01, double.MaxValue)]
		public double TotalHours { get; set; }

		/**
		 * the total cost of all the services summed together
		 */
        [Range(0.01, double.MaxValue)]
        public double TotalCost { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DatePaid { get; set; }

        /**
         * If the invoice is sent to customer or not
         */
        [DisplayName("Sent to Customer")]
        public bool IsSent { get; set; }

        [DisplayName("Due Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DueDate { get; set; }

    }
}

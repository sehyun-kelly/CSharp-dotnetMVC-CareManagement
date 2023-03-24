using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CareManagement.Models
{
    public class PurchasedServices
    {
        //[Key]
        //public Guid PurchasedServiceId { get; set; }

        [Required]
        [Key]
        [ForeignKey("Invoice")]
        public int InvoiceNumber { get; set; }
        public virtual Invoice Invoice { get; set; }

        [Required]
        [Key]
        [ForeignKey("Service")]
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }

        [Required]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        /**
         * once an invoice time period is specified we can change the range of dates allowed for an invoice
         */
        [Required]
        [Range(typeof(DateTime), "1/1/2023", "12/31/2023",
        ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime DatePurchased { get; set; }


        [Required]
        [Range(1,int.MaxValue, ErrorMessage ="Cannot have 0 services purchased.")]

        public int Quantity { get; set; }   


    }
}

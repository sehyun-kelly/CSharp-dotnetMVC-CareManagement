using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM_Team.Models
{
    public class Invoice
    {
        [Key]
        public Guid InvoiceId { get; set; }

        [Required]
        public Guid ClientId { get; set; }

        [Required]
        public double BalanceDue { get; set; }

        [Required]
        public double BalancePaid { get; set;}

        // Services optional?
        [Required]
        public bool hasServiceCharge { get; set; }
        public int? ServiceId { get; set; }

        public double? ServiceCost { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateDue { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DatePaid { get; set; }

    }
}

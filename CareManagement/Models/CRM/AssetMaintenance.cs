using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CareManagement.Models.CRM
{
    public class AssetMaintenance
    {
        [Key]
        public int TicketId { get; set; }

        // Ticket submitter can be either staff or renter
        [Required]
        public int RequestorId { get; set; }

        [Required]
        public int RequesteeId { get; set; }

        [Required]
        public bool? TicketStatus {get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [Required]
        public Guid ManagerId { get; set; }

        //Foreign Key
        [Required]
        [ForeignKey("Appliance")]
        public Guid ApplianceId { get; set; }

        public string Details { get; set; }

        public virtual Appliance? Appliance { get; set; }
    }

}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CareManagement.Models;
using CareManagement.Models.SCHDL;

namespace CareManagement.Models.CRM
{

    public class RenterService
    {

        [Key]
        public Guid RenterServiceID { get; set; }


        [Required]
        [ForeignKey("Service")]
        public Guid ServiceId { get; set; }

        public virtual Service Service { get; set; }


        [Required]
        [ForeignKey("Renter")]
        public Guid RenterId { get; set; }

        public virtual Renter Renter { get; set; }

        public string Date { get; set; }
        public float Actual_Hours { get; set; }
    }
}
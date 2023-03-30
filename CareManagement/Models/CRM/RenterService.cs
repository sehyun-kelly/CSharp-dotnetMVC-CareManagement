using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
<<<<<<< HEAD:CareManagement/Models/RenterService.cs
using CareManagement.Models;
using CRM4.Models;
=======
using CareManagement.Models.SCHDL;
>>>>>>> origin/dev:CareManagement/Models/CRM/RenterService.cs

namespace CareManagement.Models.CRM
{

    public class RenterService
    {

        [Key]
        public Guid RenterServiceID { get; set; }

        [Key]
        [Required]
        [ForeignKey("Service")]
        public Guid Service_ID { get; set; }

        public virtual Service Service { get; set; }

        [Key]
        [Required]
        [ForeignKey("Renter")]
        public Guid Renter_ID { get; set; }

        public virtual Renter Renter { get; set; }

        public string Date { get; set; }
        public float Actual_Hours { get; set; }
    }
}
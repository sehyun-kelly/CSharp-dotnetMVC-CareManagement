using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareManagement.Models.CRM
{
    public class AssetRentLog
    {
        [Key]
        [Required]
        [ForeignKey("Asset")]
        public Guid AssetId { get; set; }

        public float Asset_Cost { get; set;}
        [Required]
        [ForeignKey("Renter")]
        public Guid RenterId { get; set; }
        public string Date { get; set;}

        public virtual Renter? Renter { get; set; }

        public virtual Asset? Asset { get; set; }
    }
}

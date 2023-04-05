using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CareManagement.Models.OM;

namespace CareManagement.Models.CRM
{
    public class Appliance
    {
        [Key]
        public Guid ApplianceId { get; set; }

        [Required]
        [ForeignKey("Asset")]
        public Guid AssetId { get; set; }

        [Required]
        public Enum.ApplianceBrand ApplianceType { get; set; }

        [Required]
        public Enum.ApplianceBrand ApplianceBrand { get; set; }

        public virtual Asset? Asset { get; set; }
    }
}

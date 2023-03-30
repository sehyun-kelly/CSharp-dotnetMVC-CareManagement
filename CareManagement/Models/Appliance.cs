using System.ComponentModel.DataAnnotations;

namespace CareManagement.Models
{
    public class Appliance
    {
        [Key]
        public Guid ApplianceId { get; set; }

        [Required]
        public Guid SuiteId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string ApplianceType { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string ApplianceBrand { get; set; }
    }
}

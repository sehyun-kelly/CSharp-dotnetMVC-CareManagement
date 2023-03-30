using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareManagement.Models.CRM
{
    public class AssetRentLog
    {
        [Key]
        [Required]
        [ForeignKey("Asset")]
        public Guid Asset_ID { get; set; }

        public float Asset_Cost { get; set;}
        [Key]
        [Required]
        [ForeignKey("Client_ID")]
        public Guid Client_ID { get; set; }
        public string Date { get; set;}
    }
}

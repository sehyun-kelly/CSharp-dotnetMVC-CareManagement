
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CareManagement.Models.OM;

namespace CareManagement.Models.SCHDL
{
    public class Qualification
    {
        [Key]
        public Guid QualificationId { get; set; }

        [Required]
        [StringLength(50)]
        public string QualificationDescription { get; set; }
    }
}

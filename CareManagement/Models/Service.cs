using System.ComponentModel.DataAnnotations;

namespace CRM_Team.Models
{
    public class Service
    {
        [Key]
        [Required]
        public Guid Service_ID { get; set; }
        public float Rate { get; set; }
        //public ServiceType ServiceType { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareManagement.Models
{
    public class Schedule
    {
        [Key]
        public Guid SCHEDULE { get; set; }  
        
    }
}

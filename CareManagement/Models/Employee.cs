using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareManagement.Models
{
    public class Employee
    {
        [Key]
        [Range(0, int.MaxValue)]

        public int EMPLOYEE_ID { get; set; }

        [ForeignKey("QUALIFICATION")]
        public int Q_ID { get; set; }
        public virtual Qualification? QUALIFICATION { get; set; }
    }
}

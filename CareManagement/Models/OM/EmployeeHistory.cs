using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CareManagement.Models;

namespace CareManagement.Models.OM
{
    public class EmployeeHistory
    {
        public enum EmployeeTitle
        {
            Manager,
            Nurse,
            Librarian,
            Designer
        }

        public enum PaymentType
        {
            Hourly,
            Weekly,
            Monthly
        }

        public enum EType
        {
            Full_time,
            Part_time,
            On_call
        }

        public enum EStatus
        {
            Resigned,
            Layoff
        }

        [Required]
        [Key]
        public int EmployeeHistoryId { get; set; }

        [Required]
        [ForeignKey("Employee")]    
        public int EmployeeID {get; set; }

        [Required]
        public int PayRate { get; set; }

        [Required]
        public PaymentType PayType { get; set; }

        [Required]
        public EType EmployeeType { get; set; }


        [Required]
        [Range(0, int.MaxValue)]
        public int VacationDays { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int SickDays { get; set; }

        [Required]
        public EStatus EmployeeStatus { get; set; }

        [Required]
        public EmployeeTitle Title { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public virtual Employee Employee { get; set; }


    }
}

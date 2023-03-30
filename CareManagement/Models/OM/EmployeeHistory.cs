using System.ComponentModel.DataAnnotations;
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
        public int EmpHisId { get; set; }

        [Required]
        public EmployeeTitle Title { get; set; }

        [Required]
        public int PayRate { get; set; }

        [Required]
        public PaymentType PayType { get; set; }

        [Required]
        public EType EmpType { get; set; }

        [Required]
        public int VacationDays { get; set; }

        [Required]
        public int SickDays { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]
        public EStatus EmpStatus { get; set; }

        //Foreign key 
        [Required]
        public int EmpId { get; set; }
        public Employee Employee { get; set; }


    }
}

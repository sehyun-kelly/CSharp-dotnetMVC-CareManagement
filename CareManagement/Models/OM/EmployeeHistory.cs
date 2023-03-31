using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CareManagement.Models;


namespace CareManagement.Models.OM
{
    public class EmployeeHistory
    {

        [Required]
        [Key]
<<<<<<< HEAD
        public Guid EmployeeHistoryId { get; set; }

        [Required]
        public Enum.EmployeeTitle Title { get; set; }
=======
        public int EmployeeHistoryId { get; set; }

        [Required]
        [ForeignKey("Employee")]    
        public int EmployeeID {get; set; }
>>>>>>> dadd3550b236ad7a3fa6d9c502920e11ae0285e1

        [Required]
        public int PayRate { get; set; }

        [Required]
        public Enum.PaymentType PayType { get; set; }

        [Required]
<<<<<<< HEAD
        public Enum.EType EmployeeType { get; set; }
=======
        public EType EmployeeType { get; set; }

>>>>>>> dadd3550b236ad7a3fa6d9c502920e11ae0285e1

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
<<<<<<< HEAD

        [Required]
        public Enum.EStatus EmployeeStatus { get; set; }

        //Foreign key 
        [Required]
        [ForeignKey("Employee")]
        public Guid EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }
=======
        public virtual Employee Employee { get; set; }
>>>>>>> dadd3550b236ad7a3fa6d9c502920e11ae0285e1


    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CareManagement.Models;


namespace CareManagement.Models.OM
{
    public class EmployeeHistory
    {

        [Required]
        [Key]
        public Guid EmployeeHistoryId { get; set; }

        [Required]
        public Enum.EmployeeTitle Title { get; set; }
<<<<<<< HEAD


        [Required]
        [ForeignKey("Employee")]    
        public int EmployeeID {get; set; }
=======
>>>>>>> 3da4907398672216227ebc5a9a0136a732e2b0fb

        [Required]
        public int PayRate { get; set; }

        [Required]
        public Enum.PaymentType PayType { get; set; }

        [Required]
        public Enum.EType EmployeeType { get; set; }
<<<<<<< HEAD

=======
>>>>>>> 3da4907398672216227ebc5a9a0136a732e2b0fb

        [Required]
        public int VacationDays { get; set; }

        [Required]
        public int SickDays { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]
        public Enum.EStatus EmployeeStatus { get; set; }

        //Foreign key 
        [Required]
        [ForeignKey("Employee")]
        public Guid EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }
<<<<<<< HEAD

=======
>>>>>>> 3da4907398672216227ebc5a9a0136a732e2b0fb


    }
}
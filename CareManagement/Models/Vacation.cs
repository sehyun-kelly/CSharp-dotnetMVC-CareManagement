﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CareManagement.Models
{
    public class Vacation
    {
        [Key]
        public int VacationId { get; set; }

        [Required]
        [ForeignKey("Employee")]
        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        public string VacationRequest { get; set; }
    }

}

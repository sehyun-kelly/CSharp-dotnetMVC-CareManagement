using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CareManagement.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace CareManagement.Models.OM
{
    public class Payroll
    {
        [Key] public Guid PayrollID { get; set; }

        [Required] [ForeignKey("Employee")] public Guid EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }

        [Required] public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        [EnumDataType(typeof(EmploymentType))]
        public string? EmployeeType { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Hours { get; set; }

        [Required] [Range(0, int.MaxValue)] public int Overtime { get; set; }

        [Range(0, int.MaxValue)] public int? LateDeduction { get; set; }

        [Range(0, int.MaxValue)] public int? VacationPay { get; set; }


        [Range(0, int.MaxValue)] public int? SickPay { get; set; }

        [Range(0, int.MaxValue)] public float? Pre_tax { get; set; }

        [Range(0, int.MaxValue)] public float? Tax { get; set; }

        [Range(0, int.MaxValue)] public int? CheckAmount { get; set; }

        public enum EmploymentType
        {
            F,
            P,
            O
        }
    }
}
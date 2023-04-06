using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CareManagement.Models.OM;
using CareManagement.Models.SCHDL;

namespace CareManagement.ViewModels
{
	public class ShiftSchedulesViewModel
	{
        public Guid SelectedEmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public List<Employee> Employees { get; set; }
        public Shift DisplayedShift { get; set; }
        public List<Schedule> DisplayedSchedules { get; set; }
    }
}


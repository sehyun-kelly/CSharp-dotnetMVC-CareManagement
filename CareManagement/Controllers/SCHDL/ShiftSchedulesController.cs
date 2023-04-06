using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareManagement.Data;
using CareManagement.Models.SCHDL;
using CareManagement.Models.OM;
using CareManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using CareManagement.Models.AUTH;
using System.Security.Claims;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CareManagement.Controllers.SCHDL
{
    public class ShiftSchedulesController : Controller
    {
        private readonly CareManagementContext _context;
        private UserManager<AppUser> userManager;

        public ShiftSchedulesController(CareManagementContext context, UserManager<AppUser> usrMgr)
        {
            _context = context;
            userManager = usrMgr;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await _context.Employee.ToListAsync();
            ViewData["EmployeeSelectList"] = new SelectList(employees.Select(e => new { e.EmployeeId, FullName = e.FirstName + " " + e.LastName }), "EmployeeId", "FullName");

            var viewModel = new ShiftSchedulesViewModel
            {
                Employees = await _context.Employee.ToListAsync(),
                StartDate = DateTime.Today
            };

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            var userName = User.FindFirstValue(ClaimTypes.Name); // will give the user's userName

            System.Diagnostics.Debug.WriteLine(userId);
            System.Diagnostics.Debug.WriteLine(userName);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ShiftSchedulesViewModel model)
        {
            var employees = await _context.Employee.ToListAsync();
            ViewData["EmployeeSelectList"] = new SelectList(employees.Select(e => new { e.EmployeeId, FullName = e.FirstName + " " + e.LastName }), "EmployeeId", "FullName");

            model.Employees = await _context.Employee.ToListAsync();

            model.DisplayedShift = await _context.Shift
                .Include(s => s.Schedules)
                .FirstOrDefaultAsync(s => s.EmployeeId == model.SelectedEmployeeId
                                    && s.StartTime.Date >= model.StartDate.Date
                                    && s.EndTime.Date <= model.StartDate.AddDays(6).Date);

            if (model.DisplayedShift != null)
            {
                model.DisplayedSchedules = await _context.Schedule
                    .Include(s => s.Service)
                    .Where(s => s.ShiftID == model.DisplayedShift.ShiftId)
                    .ToListAsync();
            }
            else
            {
                model.DisplayedSchedules = new List<Schedule>();
            }

            return View(model);
        }
    }
}


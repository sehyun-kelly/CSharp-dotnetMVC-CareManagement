using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CareManagement.Data;
using CareManagement.Models.SCHDL;

namespace CareManagement.Controllers.SCHDL
{
    public class ReportController : Controller
    {
        private readonly CareManagementContext _context;

        public ReportController(CareManagementContext context)
        {
            _context = context;
        }

        // GET: Report
        public async Task<IActionResult> Index(string searchRenter, string searchService, DateTime? startTime, DateTime? endTime)
        {
            //var careManagementContext = _context.Report.Include(r => r.Renter).Include(r => r.Service);
            var reports = from m in _context.Schedule.Include(r => r.Renter).Include(r => r.Service)
                          select m;

            Console.WriteLine(startTime.ToString(), endTime.ToString());

            if (!String.IsNullOrEmpty(searchRenter))
            {
                reports = reports.Where(s => s.Renter.Name!.Contains(searchRenter));
            }
            if (!String.IsNullOrEmpty(searchService))
            {
                reports = reports.Where(s => s.Service.Type!.Contains(searchService));
            }
            if (startTime.HasValue)
            {
                reports = reports.Where(s => DateTime.Compare(s.StartTime, (DateTime)startTime) >= 0);
            }
            if (endTime.HasValue)
            {
                reports = reports.Where(s => DateTime.Compare(s.EndTime, (DateTime)endTime) <= 0);
            }


            return View(await reports.ToListAsync());
        }
    }
}

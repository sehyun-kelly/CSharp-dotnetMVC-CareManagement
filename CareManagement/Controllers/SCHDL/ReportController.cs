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
        public async Task<IActionResult> Index()
        {
            var careManagementContext = _context.Report.Include(r => r.Renter).Include(r => r.Service);
            return View();
        }

        // GET: Report/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Report == null)
            {
                return NotFound();
            }

            var report = await _context.Report
                .Include(r => r.Renter)
                .Include(r => r.Service)
                .FirstOrDefaultAsync(m => m.ReportId == id);
            if (report == null)
            {
                return NotFound();
            }

            return View(report);
        }

        // GET: Report/Create
        public IActionResult Create()
        {
            ViewData["RenterId"] = new SelectList(_context.Renter, "RenterId", "RenterId");
            ViewData["ServiceId"] = new SelectList(_context.Service, "ServiceId", "Type");
            return View();
        }

        // POST: Report/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReportId,StartTime,EndTime,RenterId,ServiceId")] Report report)
        {
            if (ModelState.IsValid)
            {
                report.ReportId = Guid.NewGuid();
                _context.Add(report);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RenterId"] = new SelectList(_context.Renter, "RenterId", "RenterId", report.RenterId);
            ViewData["ServiceId"] = new SelectList(_context.Service, "ServiceId", "Type", report.ServiceId);
            return View(report);
        }

        // GET: Report/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Report == null)
            {
                return NotFound();
            }

            var report = await _context.Report.FindAsync(id);
            if (report == null)
            {
                return NotFound();
            }
            ViewData["RenterId"] = new SelectList(_context.Renter, "RenterId", "RenterId", report.RenterId);
            ViewData["ServiceId"] = new SelectList(_context.Service, "ServiceId", "Type", report.ServiceId);
            return View(report);
        }

        // POST: Report/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ReportId,StartTime,EndTime,RenterId,ServiceId")] Report report)
        {
            if (id != report.ReportId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(report);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportExists(report.ReportId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["RenterId"] = new SelectList(_context.Renter, "RenterId", "RenterId", report.RenterId);
            ViewData["ServiceId"] = new SelectList(_context.Service, "ServiceId", "Type", report.ServiceId);
            return View(report);
        }

        // GET: Report/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Report == null)
            {
                return NotFound();
            }

            var report = await _context.Report
                .Include(r => r.Renter)
                .Include(r => r.Service)
                .FirstOrDefaultAsync(m => m.ReportId == id);
            if (report == null)
            {
                return NotFound();
            }

            return View(report);
        }

        // POST: Report/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Report == null)
            {
                return Problem("Entity set 'CareManagementContext.Report'  is null.");
            }
            var report = await _context.Report.FindAsync(id);
            if (report != null)
            {
                _context.Report.Remove(report);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReportExists(Guid id)
        {
          return (_context.Report?.Any(e => e.ReportId == id)).GetValueOrDefault();
        }
    }
}

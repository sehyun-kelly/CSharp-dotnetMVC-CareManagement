using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CareManagement.Data;
using CareManagement.Models.SCHDL;

namespace CareManagement.Controllers
{
    public class SchedulesController : Controller
    {
        private readonly CareManagementContext _context;

        public SchedulesController(CareManagementContext context)
        {
            _context = context;
        }

        // GET: Schedules
        public async Task<IActionResult> Index()
        {
            var careManagementContext = _context.Schedule.Include(s => s.Renter).Include(s => s.Service).Include(s => s.Shift);
            return View(await careManagementContext.ToListAsync());
        }

        // GET: Schedules/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Schedule == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule
                .Include(s => s.Renter)
                .Include(s => s.Service)
                .Include(s => s.Shift)
                .FirstOrDefaultAsync(m => m.ScheduleId == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // GET: Schedules/Create
        public IActionResult Create()
        {
            ViewData["RenterId"] = new SelectList(_context.Renter, "RenterId", "RenterId");
            ViewData["ServiceId"] = new SelectList(_context.Service, "ServiceId", "Type");
            ViewData["ShiftID"] = new SelectList(_context.Shift, "ShiftId", "ShiftId");
            return View();
        }

        // POST: Schedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ScheduleId,StartTime,EndTime,IsInvoiced,IsRepeating,RepeatStartDate,RepeatEndDate,RenterId,ShiftID,ServiceId")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                schedule.ScheduleId = Guid.NewGuid();
                _context.Add(schedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RenterId"] = new SelectList(_context.Renter, "RenterId", "RenterId", schedule.RenterId);
            ViewData["ServiceId"] = new SelectList(_context.Service, "ServiceId", "Type", schedule.ServiceId);
            ViewData["ShiftID"] = new SelectList(_context.Shift, "ShiftId", "ShiftId", schedule.ShiftID);
            return View(schedule);
        }

        // GET: Schedules/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Schedule == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule.FindAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }
            ViewData["RenterId"] = new SelectList(_context.Renter, "RenterId", "RenterId", schedule.RenterId);
            ViewData["ServiceId"] = new SelectList(_context.Service, "ServiceId", "Type", schedule.ServiceId);
            ViewData["ShiftID"] = new SelectList(_context.Shift, "ShiftId", "ShiftId", schedule.ShiftID);
            return View(schedule);
        }

        // POST: Schedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ScheduleId,StartTime,EndTime,IsInvoiced,IsRepeating,RepeatStartDate,RepeatEndDate,RenterId,ShiftID,ServiceId")] Schedule schedule)
        {
            if (id != schedule.ScheduleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleExists(schedule.ScheduleId))
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
            ViewData["RenterId"] = new SelectList(_context.Renter, "RenterId", "RenterId", schedule.RenterId);
            ViewData["ServiceId"] = new SelectList(_context.Service, "ServiceId", "Type", schedule.ServiceId);
            ViewData["ShiftID"] = new SelectList(_context.Shift, "ShiftId", "ShiftId", schedule.ShiftID);
            return View(schedule);
        }

        // GET: Schedules/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Schedule == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule
                .Include(s => s.Renter)
                .Include(s => s.Service)
                .Include(s => s.Shift)
                .FirstOrDefaultAsync(m => m.ScheduleId == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Schedule == null)
            {
                return Problem("Entity set 'CareManagementContext.Schedule'  is null.");
            }
            var schedule = await _context.Schedule.FindAsync(id);
            if (schedule != null)
            {
                _context.Schedule.Remove(schedule);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScheduleExists(Guid id)
        {
          return (_context.Schedule?.Any(e => e.ScheduleId == id)).GetValueOrDefault();
        }
    }
}

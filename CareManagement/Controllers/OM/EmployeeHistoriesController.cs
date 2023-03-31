using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CareManagement.Data;
using CareManagement.Models.OM;

namespace CareManagement.Controllers.OM
{
    public class EmployeeHistoriesController : Controller
    {
        private readonly CareManagementContext _context;

        public EmployeeHistoriesController(CareManagementContext context)
        {
            _context = context;
        }

        // GET: EmployeeHistories
        public async Task<IActionResult> Index()
        {
            var careManagementContext = _context.EmployeeHistory.Include(e => e.Employee);
            return View(await careManagementContext.ToListAsync());
        }

        // GET: EmployeeHistories/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.EmployeeHistory == null)
            {
                return NotFound();
            }

            var employeeHistory = await _context.EmployeeHistory
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(m => m.EmployeeHistoryId == id);
            if (employeeHistory == null)
            {
                return NotFound();
            }

            return View(employeeHistory);
        }

        // GET: EmployeeHistories/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Set<Employee>(), "EmployeeId", "Address");
            return View();
        }

        // POST: EmployeeHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeHistoryId,Title,PayRate,PayType,EmployeeType,VacationDays,SickDays,Date,EmployeeStatus,EmployeeId")] EmployeeHistory employeeHistory)
        {
            if (ModelState.IsValid)
            {
                employeeHistory.EmployeeHistoryId = Guid.NewGuid();
                _context.Add(employeeHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Set<Employee>(), "EmployeeId", "Address", employeeHistory.EmployeeId);
            return View(employeeHistory);
        }

        // GET: EmployeeHistories/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.EmployeeHistory == null)
            {
                return NotFound();
            }

            var employeeHistory = await _context.EmployeeHistory.FindAsync(id);
            if (employeeHistory == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Set<Employee>(), "EmployeeId", "Address", employeeHistory.EmployeeId);
            return View(employeeHistory);
        }

        // POST: EmployeeHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("EmployeeHistoryId,Title,PayRate,PayType,EmployeeType,VacationDays,SickDays,Date,EmployeeStatus,EmployeeId")] EmployeeHistory employeeHistory)
        {
            if (id != employeeHistory.EmployeeHistoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeHistoryExists(employeeHistory.EmployeeHistoryId))
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
            ViewData["EmployeeId"] = new SelectList(_context.Set<Employee>(), "EmployeeId", "Address", employeeHistory.EmployeeId);
            return View(employeeHistory);
        }

        // GET: EmployeeHistories/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.EmployeeHistory == null)
            {
                return NotFound();
            }

            var employeeHistory = await _context.EmployeeHistory
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(m => m.EmployeeHistoryId == id);
            if (employeeHistory == null)
            {
                return NotFound();
            }

            return View(employeeHistory);
        }

        // POST: EmployeeHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.EmployeeHistory == null)
            {
                return Problem("Entity set 'CareManagementContext.EmployeeHistory'  is null.");
            }
            var employeeHistory = await _context.EmployeeHistory.FindAsync(id);
            if (employeeHistory != null)
            {
                _context.EmployeeHistory.Remove(employeeHistory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeHistoryExists(Guid id)
        {
          return (_context.EmployeeHistory?.Any(e => e.EmployeeHistoryId == id)).GetValueOrDefault();
        }
    }
}

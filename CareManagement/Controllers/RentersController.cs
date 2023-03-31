using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CareManagement.Data;
using CareManagement.Models.CRM;

namespace CareManagement.Controllers
{
    public class RentersController : Controller
    {
        private readonly CareManagementContext _context;

        public RentersController(CareManagementContext context)
        {
            _context = context;
        }

        // GET: Renters
        public async Task<IActionResult> Index()
        {
              return _context.Renter != null ? 
                          View(await _context.Renter.ToListAsync()) :
                          Problem("Entity set 'CareManagementContext.Renter'  is null.");
        }

        // GET: Renters/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Renter == null)
            {
                return NotFound();
            }

            var renter = await _context.Renter
                .FirstOrDefaultAsync(m => m.RenterId == id);
            if (renter == null)
            {
                return NotFound();
            }

            return View(renter);
        }

        // GET: Renters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Renters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RenterId,Name,Age,Gender,Address,ContactingNumber,EmergencyContactingNumber,FamilyDoctor,SharingInfo,Income,Employer,Email")] Renter renter)
        {
            if (ModelState.IsValid)
            {
                renter.RenterId = Guid.NewGuid();
                _context.Add(renter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(renter);
        }

        // GET: Renters/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Renter == null)
            {
                return NotFound();
            }

            var renter = await _context.Renter.FindAsync(id);
            if (renter == null)
            {
                return NotFound();
            }
            return View(renter);
        }

        // POST: Renters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("RenterId,Name,Age,Gender,Address,ContactingNumber,EmergencyContactingNumber,FamilyDoctor,SharingInfo,Income,Employer,Email")] Renter renter)
        {
            if (id != renter.RenterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(renter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RenterExists(renter.RenterId))
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
            return View(renter);
        }

        // GET: Renters/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Renter == null)
            {
                return NotFound();
            }

            var renter = await _context.Renter
                .FirstOrDefaultAsync(m => m.RenterId == id);
            if (renter == null)
            {
                return NotFound();
            }

            return View(renter);
        }

        // POST: Renters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Renter == null)
            {
                return Problem("Entity set 'CareManagementContext.Renter'  is null.");
            }
            var renter = await _context.Renter.FindAsync(id);
            if (renter != null)
            {
                _context.Renter.Remove(renter);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RenterExists(Guid id)
        {
          return (_context.Renter?.Any(e => e.RenterId == id)).GetValueOrDefault();
        }
    }
}

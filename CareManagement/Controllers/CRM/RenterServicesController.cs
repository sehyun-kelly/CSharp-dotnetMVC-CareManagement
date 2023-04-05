using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CareManagement.Data;
using CareManagement.Models.CRM;

namespace CareManagement.Controllers.CRM
{
    public class RenterServicesController : Controller
    {
        private readonly CareManagementContext _context;

        public RenterServicesController(CareManagementContext context)
        {
            _context = context;
        }

        // GET: RenterServices
        public async Task<IActionResult> Index()
        {
            var careManagementContext = _context.RenterService.Include(r => r.Renter).Include(r => r.Service);
            return View(await careManagementContext.ToListAsync());
        }

        // GET: RenterServices/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.RenterService == null)
            {
                return NotFound();
            }

            var renterService = await _context.RenterService
                .Include(r => r.Renter)
                .Include(r => r.Service)
                .FirstOrDefaultAsync(m => m.RenterServiceID == id);
            if (renterService == null)
            {
                return NotFound();
            }

            return View(renterService);
        }

        // GET: RenterServices/Create
        public IActionResult Create()
        {
            ViewData["RenterId"] = new SelectList(_context.Renter, "RenterId", "RenterId");
            ViewData["ServiceId"] = new SelectList(_context.Service, "ServiceId", "Type");
            return View();
        }

        // POST: RenterServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RenterServiceID,ServiceId,RenterId,Date,Actual_Hours")] RenterService renterService)
        {
            if (ModelState.IsValid)
            {
                renterService.RenterServiceID = Guid.NewGuid();
                _context.Add(renterService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RenterId"] = new SelectList(_context.Renter, "RenterId", "RenterId", renterService.RenterId);
            ViewData["ServiceId"] = new SelectList(_context.Service, "ServiceId", "Type", renterService.ServiceId);
            return View(renterService);
        }

        // GET: RenterServices/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.RenterService == null)
            {
                return NotFound();
            }

            var renterService = await _context.RenterService.FindAsync(id);
            if (renterService == null)
            {
                return NotFound();
            }
            ViewData["RenterId"] = new SelectList(_context.Renter, "RenterId", "RenterId", renterService.RenterId);
            ViewData["ServiceId"] = new SelectList(_context.Service, "ServiceId", "Type", renterService.ServiceId);
            return View(renterService);
        }

        // POST: RenterServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("RenterServiceID,ServiceId,RenterId,Date,Actual_Hours")] RenterService renterService)
        {
            if (id != renterService.RenterServiceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(renterService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RenterServiceExists(renterService.RenterServiceID))
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
            ViewData["RenterId"] = new SelectList(_context.Renter, "RenterId", "RenterId", renterService.RenterId);
            ViewData["ServiceId"] = new SelectList(_context.Service, "ServiceId", "Type", renterService.ServiceId);
            return View(renterService);
        }

        // GET: RenterServices/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.RenterService == null)
            {
                return NotFound();
            }

            var renterService = await _context.RenterService
                .Include(r => r.Renter)
                .Include(r => r.Service)
                .FirstOrDefaultAsync(m => m.RenterServiceID == id);
            if (renterService == null)
            {
                return NotFound();
            }

            return View(renterService);
        }

        // POST: RenterServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.RenterService == null)
            {
                return Problem("Entity set 'CareManagementContext.RenterService'  is null.");
            }
            var renterService = await _context.RenterService.FindAsync(id);
            if (renterService != null)
            {
                _context.RenterService.Remove(renterService);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RenterServiceExists(Guid id)
        {
          return (_context.RenterService?.Any(e => e.RenterServiceID == id)).GetValueOrDefault();
        }
    }
}

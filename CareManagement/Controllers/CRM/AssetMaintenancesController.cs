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
    public class AssetMaintenancesController : Controller
    {
        private readonly CareManagementContext _context;

        public AssetMaintenancesController(CareManagementContext context)
        {
            _context = context;
        }

        // GET: AssetMaintenances
        public async Task<IActionResult> Index()
        {
            var careManagementContext = _context.AssetMaintenance.Include(a => a.Appliance);
            return View(await careManagementContext.ToListAsync());
        }

        // GET: AssetMaintenances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AssetMaintenance == null)
            {
                return NotFound();
            }

            var assetMaintenance = await _context.AssetMaintenance
                .Include(a => a.Appliance)
                .FirstOrDefaultAsync(m => m.TicketId == id);
            if (assetMaintenance == null)
            {
                return NotFound();
            }

            return View(assetMaintenance);
        }

        // GET: AssetMaintenances/Create
        public IActionResult Create()
        {
            ViewData["ApplianceId"] = new SelectList(_context.Appliance, "ApplianceId", "ApplianceBrand");
            return View();
        }

        // POST: AssetMaintenances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TicketId,RequestorId,RequesteeId,TicketStatus,StartDate,EndDate,ManagerId,ApplianceId,Details")] AssetMaintenance assetMaintenance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assetMaintenance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplianceId"] = new SelectList(_context.Appliance, "ApplianceId", "ApplianceBrand", assetMaintenance.ApplianceId);
            return View(assetMaintenance);
        }

        // GET: AssetMaintenances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AssetMaintenance == null)
            {
                return NotFound();
            }

            var assetMaintenance = await _context.AssetMaintenance.FindAsync(id);
            if (assetMaintenance == null)
            {
                return NotFound();
            }
            ViewData["ApplianceId"] = new SelectList(_context.Appliance, "ApplianceId", "ApplianceBrand", assetMaintenance.ApplianceId);
            return View(assetMaintenance);
        }

        // POST: AssetMaintenances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TicketId,RequestorId,RequesteeId,TicketStatus,StartDate,EndDate,ManagerId,ApplianceId,Details")] AssetMaintenance assetMaintenance)
        {
            if (id != assetMaintenance.TicketId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assetMaintenance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssetMaintenanceExists(assetMaintenance.TicketId))
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
            ViewData["ApplianceId"] = new SelectList(_context.Appliance, "ApplianceId", "ApplianceBrand", assetMaintenance.ApplianceId);
            return View(assetMaintenance);
        }

        // GET: AssetMaintenances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AssetMaintenance == null)
            {
                return NotFound();
            }

            var assetMaintenance = await _context.AssetMaintenance
                .Include(a => a.Appliance)
                .FirstOrDefaultAsync(m => m.TicketId == id);
            if (assetMaintenance == null)
            {
                return NotFound();
            }

            return View(assetMaintenance);
        }

        // POST: AssetMaintenances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AssetMaintenance == null)
            {
                return Problem("Entity set 'CareManagementContext.AssetMaintenance'  is null.");
            }
            var assetMaintenance = await _context.AssetMaintenance.FindAsync(id);
            if (assetMaintenance != null)
            {
                _context.AssetMaintenance.Remove(assetMaintenance);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssetMaintenanceExists(int id)
        {
          return (_context.AssetMaintenance?.Any(e => e.TicketId == id)).GetValueOrDefault();
        }
    }
}

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
    public class AppliancesController : Controller
    {
        private readonly CareManagementContext _context;

        public AppliancesController(CareManagementContext context)
        {
            _context = context;
        }

        // GET: Appliances
        public async Task<IActionResult> Index()
        {
            var careManagementContext = _context.Appliance.Include(a => a.Asset);
            return View(await careManagementContext.ToListAsync());
        }

        // GET: Appliances/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Appliance == null)
            {
                return NotFound();
            }

            var appliance = await _context.Appliance
                .Include(a => a.Asset)
                .FirstOrDefaultAsync(m => m.ApplianceId == id);
            if (appliance == null)
            {
                return NotFound();
            }

            return View(appliance);
        }

        // GET: Appliances/Create
        public IActionResult Create()
        {
            ViewData["AssetId"] = new SelectList(_context.Asset, "AssetId", "AssetId");
            return View();
        }

        // POST: Appliances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplianceId,AssetId,ApplianceType,ApplianceBrand")] Appliance appliance)
        {
            if (ModelState.IsValid)
            {
                appliance.ApplianceId = Guid.NewGuid();
                _context.Add(appliance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssetId"] = new SelectList(_context.Asset, "AssetId", "AssetId", appliance.AssetId);
            return View(appliance);
        }

        // GET: Appliances/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Appliance == null)
            {
                return NotFound();
            }

            var appliance = await _context.Appliance.FindAsync(id);
            if (appliance == null)
            {
                return NotFound();
            }
            ViewData["AssetId"] = new SelectList(_context.Asset, "AssetId", "AssetId", appliance.AssetId);
            return View(appliance);
        }

        // POST: Appliances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ApplianceId,AssetId,ApplianceType,ApplianceBrand")] Appliance appliance)
        {
            if (id != appliance.ApplianceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appliance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplianceExists(appliance.ApplianceId))
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
            ViewData["AssetId"] = new SelectList(_context.Asset, "AssetId", "AssetId", appliance.AssetId);
            return View(appliance);
        }

        // GET: Appliances/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Appliance == null)
            {
                return NotFound();
            }

            var appliance = await _context.Appliance
                .Include(a => a.Asset)
                .FirstOrDefaultAsync(m => m.ApplianceId == id);
            if (appliance == null)
            {
                return NotFound();
            }

            return View(appliance);
        }

        // POST: Appliances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Appliance == null)
            {
                return Problem("Entity set 'CareManagementContext.Appliance'  is null.");
            }
            var appliance = await _context.Appliance.FindAsync(id);
            if (appliance != null)
            {
                _context.Appliance.Remove(appliance);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplianceExists(Guid id)
        {
          return (_context.Appliance?.Any(e => e.ApplianceId == id)).GetValueOrDefault();
        }
    }
}

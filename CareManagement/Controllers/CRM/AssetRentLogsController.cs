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
    public class AssetRentLogsController : Controller
    {
        private readonly CareManagementContext _context;

        public AssetRentLogsController(CareManagementContext context)
        {
            _context = context;
        }

        // GET: AssetRentLogs
        public async Task<IActionResult> Index()
        {
            var careManagementContext = _context.AssetRentLog.Include(a => a.Asset).Include(a => a.Renter);
            return View(await careManagementContext.ToListAsync());
        }

        // GET: AssetRentLogs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.AssetRentLog == null)
            {
                return NotFound();
            }

            var assetRentLog = await _context.AssetRentLog
                .Include(a => a.Asset)
                .Include(a => a.Renter)
                .FirstOrDefaultAsync(m => m.AssetId == id);
            if (assetRentLog == null)
            {
                return NotFound();
            }

            return View(assetRentLog);
        }

        // GET: AssetRentLogs/Create
        public IActionResult Create()
        {
            ViewData["AssetId"] = new SelectList(_context.Asset, "AssetId", "AssetId");
            ViewData["RenterId"] = new SelectList(_context.Renter, "RenterId", "RenterId");
            return View();
        }

        // POST: AssetRentLogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssetId,Asset_Cost,RenterId,Date")] AssetRentLog assetRentLog)
        {
            if (ModelState.IsValid)
            {
                assetRentLog.AssetId = Guid.NewGuid();
                _context.Add(assetRentLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssetId"] = new SelectList(_context.Asset, "AssetId", "AssetId", assetRentLog.AssetId);
            ViewData["RenterId"] = new SelectList(_context.Renter, "RenterId", "RenterId", assetRentLog.RenterId);
            return View(assetRentLog);
        }

        // GET: AssetRentLogs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.AssetRentLog == null)
            {
                return NotFound();
            }

            var assetRentLog = await _context.AssetRentLog.FindAsync(id);
            if (assetRentLog == null)
            {
                return NotFound();
            }
            ViewData["AssetId"] = new SelectList(_context.Asset, "AssetId", "AssetId", assetRentLog.AssetId);
            ViewData["RenterId"] = new SelectList(_context.Renter, "RenterId", "RenterId", assetRentLog.RenterId);
            return View(assetRentLog);
        }

        // POST: AssetRentLogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("AssetId,Asset_Cost,RenterId,Date")] AssetRentLog assetRentLog)
        {
            if (id != assetRentLog.AssetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assetRentLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssetRentLogExists(assetRentLog.AssetId))
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
            ViewData["AssetId"] = new SelectList(_context.Asset, "AssetId", "AssetId", assetRentLog.AssetId);
            ViewData["RenterId"] = new SelectList(_context.Renter, "RenterId", "RenterId", assetRentLog.RenterId);
            return View(assetRentLog);
        }

        // GET: AssetRentLogs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.AssetRentLog == null)
            {
                return NotFound();
            }

            var assetRentLog = await _context.AssetRentLog
                .Include(a => a.Asset)
                .Include(a => a.Renter)
                .FirstOrDefaultAsync(m => m.AssetId == id);
            if (assetRentLog == null)
            {
                return NotFound();
            }

            return View(assetRentLog);
        }

        // POST: AssetRentLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.AssetRentLog == null)
            {
                return Problem("Entity set 'CareManagementContext.AssetRentLog'  is null.");
            }
            var assetRentLog = await _context.AssetRentLog.FindAsync(id);
            if (assetRentLog != null)
            {
                _context.AssetRentLog.Remove(assetRentLog);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssetRentLogExists(Guid id)
        {
          return (_context.AssetRentLog?.Any(e => e.AssetId == id)).GetValueOrDefault();
        }
    }
}

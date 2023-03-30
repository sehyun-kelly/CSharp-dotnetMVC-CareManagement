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
    public class PurchasedServicesController : Controller
    {
        private readonly CareManagementContext _context;

        public PurchasedServicesController(CareManagementContext context)
        {
            _context = context;
        }

        // GET: PurchasedServices
        public async Task<IActionResult> Index()
        {
              return _context.PurchasedServices != null ? 
                          View(await _context.PurchasedServices.ToListAsync()) :
                          Problem("Entity set 'CareManagementContext.PurchasedServices'  is null.");
        }

        // GET: PurchasedServices/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.PurchasedServices == null)
            {
                return NotFound();
            }

            var purchasedServices = await _context.PurchasedServices
                .FirstOrDefaultAsync(m => m.PurchasedServiceId == id);
            if (purchasedServices == null)
            {
                return NotFound();
            }

            return View(purchasedServices);
        }

        // GET: PurchasedServices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PurchasedServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PurchasedServiceId,DatePurchased,Quantity")] PurchasedServices purchasedServices)
        {
            if (ModelState.IsValid)
            {
                purchasedServices.PurchasedServiceId = Guid.NewGuid();
                _context.Add(purchasedServices);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(purchasedServices);
        }

        // GET: PurchasedServices/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.PurchasedServices == null)
            {
                return NotFound();
            }

            var purchasedServices = await _context.PurchasedServices.FindAsync(id);
            if (purchasedServices == null)
            {
                return NotFound();
            }
            return View(purchasedServices);
        }

        // POST: PurchasedServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PurchasedServiceId,DatePurchased,Quantity")] PurchasedServices purchasedServices)
        {
            if (id != purchasedServices.PurchasedServiceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchasedServices);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchasedServicesExists(purchasedServices.PurchasedServiceId))
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
            return View(purchasedServices);
        }

        // GET: PurchasedServices/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.PurchasedServices == null)
            {
                return NotFound();
            }

            var purchasedServices = await _context.PurchasedServices
                .FirstOrDefaultAsync(m => m.PurchasedServiceId == id);
            if (purchasedServices == null)
            {
                return NotFound();
            }

            return View(purchasedServices);
        }

        // POST: PurchasedServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.PurchasedServices == null)
            {
                return Problem("Entity set 'CareManagementContext.PurchasedServices'  is null.");
            }
            var purchasedServices = await _context.PurchasedServices.FindAsync(id);
            if (purchasedServices != null)
            {
                _context.PurchasedServices.Remove(purchasedServices);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchasedServicesExists(Guid id)
        {
          return (_context.PurchasedServices?.Any(e => e.PurchasedServiceId == id)).GetValueOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CareManagement.Data;
using CareManagement.Models.SCHDL;
using EmailService;
using System.Text.Json;

namespace CareManagement.Controllers.SCHDL
{
    public class InvoicesController : Controller
    {
        private readonly CareManagementContext _context;

        public InvoicesController(CareManagementContext context)
        {
            _context = context;
        }

        // GET: Invoices
        public async Task<IActionResult> Index(string sortOrder)
        {
            //ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["StartDateSortParm"] = sortOrder == "StartDate" ? "date_desc" : "StartDate";
            ViewData["EndDateSortParm"] = sortOrder == "EndDate" ? "end_date_desc" : "EndDate";
            ViewData["TotalHoursSortParm"] = sortOrder == "TotalHours" ? "total_hrs_desc" : "TotalHours";
            ViewData["TotalCostSortParm"] = sortOrder == "TotalCost" ? "total_cost_desc" : "TotalCost";
            ViewData["DatePaidSortParm"] = sortOrder == "DatePaid" ? "date_paid_desc" : "DatePaid";
            ViewData["IsSentSortParm"] = sortOrder == "IsSent" ? "is_sent_false" : "IsSent";
            ViewData["DueDateSortParm"] = sortOrder == "DueDate" ? "due_date_desc" : "DueDate";
            var invoices = from i in _context.Invoice
                           select i;
            switch (sortOrder)
            {
                //case "name_desc":
                //    invoices = invoices.OrderByDescending(i => i.Renter);
                //    break;
                case "StartDate":
                    invoices = invoices.OrderBy(i => i.StartDate);
                    break;
                case "date_desc":
                    invoices = invoices.OrderByDescending(i => i.StartDate);
                    break;
                case "EndDate":
                    invoices = invoices.OrderBy(i => i.EndDate);
                    break;
                case "end_date_desc":
                    invoices = invoices.OrderByDescending(i => i.EndDate);
                    break;
                case "TotalHours":
                    invoices = invoices.OrderBy(i => i.TotalHours);
                    break;
                case "total_hrs_desc":
                    invoices = invoices.OrderByDescending(i => i.TotalHours);
                    break;
                case "TotalCost":
                    invoices = invoices.OrderBy(i => i.TotalCost);
                    break;
                case "total_cost_desc":
                    invoices = invoices.OrderByDescending(i => i.TotalCost);
                    break;
                case "DatePaid":
                    invoices = invoices.OrderBy(i => i.DatePaid);
                    break;
                case "date_paid_desc":
                    invoices = invoices.OrderByDescending(i => i.DatePaid);
                    break;
                case "DueDate":
                    invoices = invoices.OrderBy(i => i.DueDate);
                    break;
                case "due_date_desc":
                    invoices = invoices.OrderByDescending(i => i.DueDate);
                    break;
                case "IsSent":
                    invoices = invoices.Where(i => i.IsSent == true);
                    break;
                case "is_sent_false":
                    invoices = invoices.Where(i => i.IsSent == false);
                    break;
                default:
                    invoices = invoices.OrderBy(i => i.StartDate);
                    break;
            }
            return View(await invoices.AsNoTracking().ToListAsync());
        }
        //public async Task<IActionResult> Index()
        //{
        //      return _context.Invoice != null ? 
        //                  View(await _context.Invoice.ToListAsync()) :
        //                  Problem("Entity set 'CareManagementContext.Invoice'  is null.");
        //}

        // GET: Invoices/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Invoice == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice
                .FirstOrDefaultAsync(m => m.InvoiceNumber == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // GET: Invoices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InvoiceNumber,StartDate,EndDate,TotalHours,TotalCost,DatePaid")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                invoice.InvoiceNumber = Guid.NewGuid();
                _context.Add(invoice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invoice);
        }

        // GET: Invoices/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Invoice == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("InvoiceNumber,StartDate,EndDate,TotalHours,TotalCost,DatePaid")] Invoice invoice)
        {
            if (id != invoice.InvoiceNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceExists(invoice.InvoiceNumber))
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
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Invoice == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice
                .FirstOrDefaultAsync(m => m.InvoiceNumber == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Invoice == null)
            {
                return Problem("Entity set 'CareManagementContext.Invoice'  is null.");
            }
            var invoice = await _context.Invoice.FindAsync(id);
            if (invoice != null)
            {
                _context.Invoice.Remove(invoice);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceExists(Guid id)
        {
          return (_context.Invoice?.Any(e => e.InvoiceNumber == id)).GetValueOrDefault();
        }

        // GET: Invoices/Email/5
        public async Task<IActionResult> Email(Guid? id)
        {
            if (id == null || _context.Invoice == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice
                .FirstOrDefaultAsync(m => m.InvoiceNumber == id);
            if (invoice == null)
            {
                return NotFound();
            }
            // Invoice is sent to Renter
            invoice.IsSent = true;

            var content = "Invoice From Care Management: \n"
                + "| Invoice Number: " + invoice.InvoiceNumber + "\n"
                + "| Start Date: " + invoice.StartDate + "\n"
                + "| End Date: " + invoice.EndDate + "\n"
                + "| Total Hours: " + invoice.TotalHours + "\n"
                + "| Total Cost: " + invoice.TotalCost + "\n"
                + "| Date Paid: " + invoice.DatePaid + "\n"
                + "| Sent To Renter: " + (invoice.IsSent ? "Yes" : "No") + "\n"
                + "| Due Date: " + invoice.DueDate + "\n";
            
            TempData["Invoice"] = content;

            return RedirectToAction("Index", "Email");
        }
    }
}

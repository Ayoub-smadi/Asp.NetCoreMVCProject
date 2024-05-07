using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GG.Models;

namespace GG.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ModelContext _context;

        public TransactionsController(ModelContext context)
        {
            _context = context;
        }

        // GET: Transactions
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Transactions.Include(t => t.Recipe).Include(t => t.User);
            return View(await modelContext.ToListAsync());
        }

        // GET: Transactions/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null || _context.Transactions == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions
                .Include(t => t.Recipe)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.Transactionid == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // GET: Transactions/Create
        public IActionResult Create()
        {
            ViewData["Recipeid"] = new SelectList(_context.Recipes, "Recipeid", "Recipeid");
            ViewData["Userid"] = new SelectList(_context.Users, "Userid", "Userid");
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Transactionid,Userid,Recipeid,Amount,Paymentstatus,Paymentdate")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Recipeid"] = new SelectList(_context.Recipes, "Recipeid", "Recipeid", transaction.Recipeid);
            ViewData["Userid"] = new SelectList(_context.Users, "Userid", "Userid", transaction.Userid);
            return View(transaction);
        }

        // GET: Transactions/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null || _context.Transactions == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            ViewData["Recipeid"] = new SelectList(_context.Recipes, "Recipeid", "Recipeid", transaction.Recipeid);
            ViewData["Userid"] = new SelectList(_context.Users, "Userid", "Userid", transaction.Userid);
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Transactionid,Userid,Recipeid,Amount,Paymentstatus,Paymentdate")] Transaction transaction)
        {
            if (id != transaction.Transactionid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(transaction.Transactionid))
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
            ViewData["Recipeid"] = new SelectList(_context.Recipes, "Recipeid", "Recipeid", transaction.Recipeid);
            ViewData["Userid"] = new SelectList(_context.Users, "Userid", "Userid", transaction.Userid);
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null || _context.Transactions == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions
                .Include(t => t.Recipe)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.Transactionid == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            if (_context.Transactions == null)
            {
                return Problem("Entity set 'ModelContext.Transactions'  is null.");
            }
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionExists(decimal id)
        {
          return (_context.Transactions?.Any(e => e.Transactionid == id)).GetValueOrDefault();
        }
    }
}

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
    public class ReciperequestsController : Controller
    {
        private readonly ModelContext _context;

        public ReciperequestsController(ModelContext context)
        {
            _context = context;
        }

        // GET: Reciperequests
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Reciperequests.Include(r => r.Recipe).Include(r => r.User);
            return View(await modelContext.ToListAsync());
        }

        // GET: Reciperequests/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null || _context.Reciperequests == null)
            {
                return NotFound();
            }

            var reciperequest = await _context.Reciperequests
                .Include(r => r.Recipe)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Requestid == id);
            if (reciperequest == null)
            {
                return NotFound();
            }

            return View(reciperequest);
        }

        // GET: Reciperequests/Create
        public IActionResult Create()
        {
            ViewData["Recipeid"] = new SelectList(_context.Recipes, "Recipeid", "Recipeid");
            ViewData["Userid"] = new SelectList(_context.Users, "Userid", "Userid");
            return View();
        }

        // POST: Reciperequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Requestid,Userid,Recipeid,Status,Requestdate")] Reciperequest reciperequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reciperequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Recipeid"] = new SelectList(_context.Recipes, "Recipeid", "Recipeid", reciperequest.Recipeid);
            ViewData["Userid"] = new SelectList(_context.Users, "Userid", "Userid", reciperequest.Userid);
            return View(reciperequest);
        }

        // GET: Reciperequests/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null || _context.Reciperequests == null)
            {
                return NotFound();
            }

            var reciperequest = await _context.Reciperequests.FindAsync(id);
            if (reciperequest == null)
            {
                return NotFound();
            }
            ViewData["Recipeid"] = new SelectList(_context.Recipes, "Recipeid", "Recipeid", reciperequest.Recipeid);
            ViewData["Userid"] = new SelectList(_context.Users, "Userid", "Userid", reciperequest.Userid);
            return View(reciperequest);
        }

        // POST: Reciperequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Requestid,Userid,Recipeid,Status,Requestdate")] Reciperequest reciperequest)
        {
            if (id != reciperequest.Requestid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reciperequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReciperequestExists(reciperequest.Requestid))
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
            ViewData["Recipeid"] = new SelectList(_context.Recipes, "Recipeid", "Recipeid", reciperequest.Recipeid);
            ViewData["Userid"] = new SelectList(_context.Users, "Userid", "Userid", reciperequest.Userid);
            return View(reciperequest);
        }

        // GET: Reciperequests/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null || _context.Reciperequests == null)
            {
                return NotFound();
            }

            var reciperequest = await _context.Reciperequests
                .Include(r => r.Recipe)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Requestid == id);
            if (reciperequest == null)
            {
                return NotFound();
            }

            return View(reciperequest);
        }

        // POST: Reciperequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            if (_context.Reciperequests == null)
            {
                return Problem("Entity set 'ModelContext.Reciperequests'  is null.");
            }
            var reciperequest = await _context.Reciperequests.FindAsync(id);
            if (reciperequest != null)
            {
                _context.Reciperequests.Remove(reciperequest);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReciperequestExists(decimal id)
        {
          return (_context.Reciperequests?.Any(e => e.Requestid == id)).GetValueOrDefault();
        }
    }
}

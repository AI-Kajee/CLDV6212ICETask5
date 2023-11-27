using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoD_Command_Center.Models;

namespace CoD_Command_Center.Controllers
{
    public class CodeventsController : Controller
    {
        private readonly CoDCommandCenterContext _context;

        public CodeventsController(CoDCommandCenterContext context)
        {
            _context = context;
        }

        // GET: Codevents
        public async Task<IActionResult> Index()
        {
            return View(await _context.Codevents.ToListAsync());
        }

        // GET: Codevents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codevent = await _context.Codevents
                .FirstOrDefaultAsync(m => m.EId == id);
            if (codevent == null)
            {
                return NotFound();
            }

            return View(codevent);
        }

        // GET: Codevents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Codevents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EId,EventName,EventDetails,EStartDate,EEndDate")] Codevent codevent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(codevent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(codevent);
        }

        // GET: Codevents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codevent = await _context.Codevents.FindAsync(id);
            if (codevent == null)
            {
                return NotFound();
            }
            return View(codevent);
        }

        // POST: Codevents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EId,EventName,EventDetails,EStartDate,EEndDate")] Codevent codevent)
        {
            if (id != codevent.EId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(codevent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CodeventExists(codevent.EId))
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
            return View(codevent);
        }

        // GET: Codevents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codevent = await _context.Codevents
                .FirstOrDefaultAsync(m => m.EId == id);
            if (codevent == null)
            {
                return NotFound();
            }

            return View(codevent);
        }

        // POST: Codevents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var codevent = await _context.Codevents.FindAsync(id);
            if (codevent != null)
            {
                _context.Codevents.Remove(codevent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CodeventExists(int id)
        {
            return _context.Codevents.Any(e => e.EId == id);
        }
    }
}

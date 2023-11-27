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
    public class NewsAndUpdateController : Controller
    {
        private readonly CoDCommandCenterContext _context;

        public NewsAndUpdateController(CoDCommandCenterContext context)
        {
            _context = context;
        }

        // GET: NewsAndUpdate
        public async Task<IActionResult> Index()
        {
            return View(await _context.NewsAndUpdates.ToListAsync());
        }

        // GET: NewsAndUpdate/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsAndUpdate = await _context.NewsAndUpdates
                .FirstOrDefaultAsync(m => m.AId == id);
            if (newsAndUpdate == null)
            {
                return NotFound();
            }

            return View(newsAndUpdate);
        }

        // GET: NewsAndUpdate/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NewsAndUpdate/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AId,ArticleName,ArticleDescription,ACreatedAt,AUpdatedAt")] NewsAndUpdate newsAndUpdate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newsAndUpdate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newsAndUpdate);
        }

        // GET: NewsAndUpdate/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsAndUpdate = await _context.NewsAndUpdates.FindAsync(id);
            if (newsAndUpdate == null)
            {
                return NotFound();
            }
            return View(newsAndUpdate);
        }

        // POST: NewsAndUpdate/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AId,ArticleName,ArticleDescription,ACreatedAt,AUpdatedAt")] NewsAndUpdate newsAndUpdate)
        {
            if (id != newsAndUpdate.AId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newsAndUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsAndUpdateExists(newsAndUpdate.AId))
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
            return View(newsAndUpdate);
        }

        // GET: NewsAndUpdate/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsAndUpdate = await _context.NewsAndUpdates
                .FirstOrDefaultAsync(m => m.AId == id);
            if (newsAndUpdate == null)
            {
                return NotFound();
            }

            return View(newsAndUpdate);
        }

        // POST: NewsAndUpdate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newsAndUpdate = await _context.NewsAndUpdates.FindAsync(id);
            if (newsAndUpdate != null)
            {
                _context.NewsAndUpdates.Remove(newsAndUpdate);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsAndUpdateExists(int id)
        {
            return _context.NewsAndUpdates.Any(e => e.AId == id);
        }
    }
}

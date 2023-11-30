using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoD_Command_Center.Models;
using Microsoft.AspNetCore.Authorization;

namespace CoD_Command_Center.Controllers
{
    [Authorize]
    public class User1Controller : Controller
    {
        private readonly CoDCommandCenterContext _context;

        public User1Controller(CoDCommandCenterContext context)
        {
            _context = context;
        }

        // GET: User1
        public async Task<IActionResult> Index()
        {
            return View(await _context.User1s.ToListAsync());
        }

        // GET: User1/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user1 = await _context.User1s
                .FirstOrDefaultAsync(m => m.UserName == id);
            if (user1 == null)
            {
                return NotFound();
            }

            return View(user1);
        }

        // GET: User1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserName,FirstName,LastName,EmailAddress,NickName,KillCount,Level,Badge,KnockoutRatio,Ranking")] User1 user1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user1);
        }

        // GET: User1/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user1 = await _context.User1s.FindAsync(id);
            if (user1 == null)
            {
                return NotFound();
            }
            return View(user1);
        }

        // POST: User1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserName,FirstName,LastName,EmailAddress,NickName,KillCount,Level,Badge,KnockoutRatio,Ranking")] User1 user1)
        {
            if (id != user1.UserName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!User1Exists(user1.UserName))
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
            return View(user1);
        }

        // GET: User1/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user1 = await _context.User1s
                .FirstOrDefaultAsync(m => m.UserName == id);
            if (user1 == null)
            {
                return NotFound();
            }

            return View(user1);
        }

        // POST: User1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user1 = await _context.User1s.FindAsync(id);
            if (user1 != null)
            {
                _context.User1s.Remove(user1);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool User1Exists(string id)
        {
            return _context.User1s.Any(e => e.UserName == id);
        }
    }
}

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
    public class LeaderBoardController : Controller
    {
        private readonly CoDCommandCenterContext _context;

        public LeaderBoardController(CoDCommandCenterContext context)
        {
            _context = context;
        }

        // GET: LeaderBoard
        public async Task<IActionResult> Index()
        {
            var coDCommandCenterContext = _context.LeaderBoards.Include(l => l.UserNameNavigation);
            return View(await coDCommandCenterContext.ToListAsync());
        }

        // GET: LeaderBoard/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaderBoard = await _context.LeaderBoards
                .Include(l => l.UserNameNavigation)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (leaderBoard == null)
            {
                return NotFound();
            }

            return View(leaderBoard);
        }

        // GET: LeaderBoard/Create
        public IActionResult Create()
        {
            ViewData["UserName"] = new SelectList(_context.User1s, "UserName", "UserName");
            return View();
        }

        // POST: LeaderBoard/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,BoardRanking,KillCount,Level,UserName")] LeaderBoard leaderBoard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leaderBoard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserName"] = new SelectList(_context.User1s, "UserName", "UserName", leaderBoard.UserName);
            return View(leaderBoard);
        }

        // GET: LeaderBoard/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaderBoard = await _context.LeaderBoards.FindAsync(id);
            if (leaderBoard == null)
            {
                return NotFound();
            }
            ViewData["UserName"] = new SelectList(_context.User1s, "UserName", "UserName", leaderBoard.UserName);
            return View(leaderBoard);
        }

        // POST: LeaderBoard/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserId,BoardRanking,KillCount,Level,UserName")] LeaderBoard leaderBoard)
        {
            if (id != leaderBoard.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leaderBoard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaderBoardExists(leaderBoard.UserId))
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
            ViewData["UserName"] = new SelectList(_context.User1s, "UserName", "UserName", leaderBoard.UserName);
            return View(leaderBoard);
        }

        // GET: LeaderBoard/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaderBoard = await _context.LeaderBoards
                .Include(l => l.UserNameNavigation)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (leaderBoard == null)
            {
                return NotFound();
            }

            return View(leaderBoard);
        }

        // POST: LeaderBoard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var leaderBoard = await _context.LeaderBoards.FindAsync(id);
            if (leaderBoard != null)
            {
                _context.LeaderBoards.Remove(leaderBoard);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaderBoardExists(string id)
        {
            return _context.LeaderBoards.Any(e => e.UserId == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bookstore_App.Data;
using Bookstore_App.Models;

namespace Bookstore_App.Controllers
{
    public class BoardGamesController : Controller
    {
        private readonly Bookstore_AppContext _context;

        public BoardGamesController(Bookstore_AppContext context)
        {
            _context = context;
        }

        // GET: BoardGames
        public async Task<IActionResult> Index()
        {
              return _context.BoardGames != null ? 
                          View(await _context.BoardGames.ToListAsync()) :
                          Problem("Entity set 'Bookstore_AppContext.BoardGames'  is null.");
        }

        // GET: BoardGames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BoardGames == null)
            {
                return NotFound();
            }

            var boardGames = await _context.BoardGames
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boardGames == null)
            {
                return NotFound();
            }

            return View(boardGames);
        }

        // GET: BoardGames/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BoardGames/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Genre,NoPlayers,MinAge,Price")] BoardGames boardGames)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boardGames);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(boardGames);
        }

        // GET: BoardGames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BoardGames == null)
            {
                return NotFound();
            }

            var boardGames = await _context.BoardGames.FindAsync(id);
            if (boardGames == null)
            {
                return NotFound();
            }
            return View(boardGames);
        }

        // POST: BoardGames/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Genre,NoPlayers,MinAge,Price")] BoardGames boardGames)
        {
            if (id != boardGames.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boardGames);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoardGamesExists(boardGames.Id))
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
            return View(boardGames);
        }

        // GET: BoardGames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BoardGames == null)
            {
                return NotFound();
            }

            var boardGames = await _context.BoardGames
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boardGames == null)
            {
                return NotFound();
            }

            return View(boardGames);
        }

        // POST: BoardGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BoardGames == null)
            {
                return Problem("Entity set 'Bookstore_AppContext.BoardGames'  is null.");
            }
            var boardGames = await _context.BoardGames.FindAsync(id);
            if (boardGames != null)
            {
                _context.BoardGames.Remove(boardGames);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoardGamesExists(int id)
        {
          return (_context.BoardGames?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

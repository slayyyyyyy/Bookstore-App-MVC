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
    public class GraphicBooksController : Controller
    {
        private readonly Bookstore_AppContext _context;

        public GraphicBooksController(Bookstore_AppContext context)
        {
            _context = context;
        }

        // GET: GraphicBooks
        public async Task<IActionResult> Index()
        {
              return _context.GraphicBook != null ? 
                          View(await _context.GraphicBook.ToListAsync()) :
                          Problem("Entity set 'Bookstore_AppContext.GraphicBook'  is null.");
        }

        // GET: GraphicBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GraphicBook == null)
            {
                return NotFound();
            }

            var graphicBook = await _context.GraphicBook
                .FirstOrDefaultAsync(m => m.Id == id);
            if (graphicBook == null)
            {
                return NotFound();
            }

            return View(graphicBook);
        }

        // GET: GraphicBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GraphicBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Author,Type,Genre,Price")] GraphicBook graphicBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(graphicBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(graphicBook);
        }

        // GET: GraphicBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GraphicBook == null)
            {
                return NotFound();
            }

            var graphicBook = await _context.GraphicBook.FindAsync(id);
            if (graphicBook == null)
            {
                return NotFound();
            }
            return View(graphicBook);
        }

        // POST: GraphicBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Author,Type,Genre,Price")] GraphicBook graphicBook)
        {
            if (id != graphicBook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(graphicBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GraphicBookExists(graphicBook.Id))
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
            return View(graphicBook);
        }

        // GET: GraphicBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GraphicBook == null)
            {
                return NotFound();
            }

            var graphicBook = await _context.GraphicBook
                .FirstOrDefaultAsync(m => m.Id == id);
            if (graphicBook == null)
            {
                return NotFound();
            }

            return View(graphicBook);
        }

        // POST: GraphicBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GraphicBook == null)
            {
                return Problem("Entity set 'Bookstore_AppContext.GraphicBook'  is null.");
            }
            var graphicBook = await _context.GraphicBook.FindAsync(id);
            if (graphicBook != null)
            {
                _context.GraphicBook.Remove(graphicBook);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GraphicBookExists(int id)
        {
          return (_context.GraphicBook?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

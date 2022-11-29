using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using movie_rating_app.Data;
using movie_rating_app.Models;

namespace movie_rating_app.Controllers
{
    public class FavouritesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FavouritesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Favourites
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Favourites.Include(f => f.Movie).Include(f => f.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Favourites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Favourites == null)
            {
                return NotFound();
            }

            var favourite = await _context.Favourites
                .Include(f => f.Movie)
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (favourite == null)
            {
                return NotFound();
            }

            return View(favourite);
        }

        // GET: Favourites/Create
        public IActionResult Create()
        {
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Favourites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,MovieId,Id")] Favourite favourite)
        {
            if (ModelState.IsValid)
            {
                _context.Add(favourite);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title", favourite.MovieId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", favourite.UserId);
            return View(favourite);
        }

        // GET: Favourites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Favourites == null)
            {
                return NotFound();
            }

            var favourite = await _context.Favourites.FindAsync(id);
            if (favourite == null)
            {
                return NotFound();
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title", favourite.MovieId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", favourite.UserId);
            return View(favourite);
        }

        // POST: Favourites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,MovieId,Id")] Favourite favourite)
        {
            if (id != favourite.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(favourite);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FavouriteExists(favourite.Id))
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
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title", favourite.MovieId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", favourite.UserId);
            return View(favourite);
        }

        // GET: Favourites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Favourites == null)
            {
                return NotFound();
            }

            var favourite = await _context.Favourites
                .Include(f => f.Movie)
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (favourite == null)
            {
                return NotFound();
            }

            return View(favourite);
        }

        // POST: Favourites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Favourites == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Favourites'  is null.");
            }
            var favourite = await _context.Favourites.FindAsync(id);
            if (favourite != null)
            {
                _context.Favourites.Remove(favourite);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FavouriteExists(int id)
        {
          return _context.Favourites.Any(e => e.Id == id);
        }
    }
}

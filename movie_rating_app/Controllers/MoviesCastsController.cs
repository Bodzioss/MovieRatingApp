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
    public class MoviesCastsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesCastsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MoviesCasts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MoviesCasts.Include(m => m.Actor).Include(m => m.Movie).Include(m => m.Role);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MoviesCasts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MoviesCasts == null)
            {
                return NotFound();
            }

            var moviesCast = await _context.MoviesCasts
                .Include(m => m.Actor)
                .Include(m => m.Movie)
                .Include(m => m.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moviesCast == null)
            {
                return NotFound();
            }

            return View(moviesCast);
        }

        // GET: MoviesCasts/Create
        public IActionResult Create()
        {
            ViewData["ActorId"] = new SelectList(_context.Actors, "Id", "PersonName");
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title");
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name");
            return View();
        }

        // POST: MoviesCasts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MovieId,ActorId,RoleId")] MoviesCast moviesCast)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moviesCast);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var errors = ModelState
            .Where(x => x.Value.Errors.Count > 0)
            .Select(x => new { x.Key, x.Value.Errors })
            .ToArray();
            ViewData["ActorId"] = new SelectList(_context.Actors, "Id", "PersonName", moviesCast.ActorId);
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title", moviesCast.MovieId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name", moviesCast.RoleId);
            return View(moviesCast);
        }

        // GET: MoviesCasts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MoviesCasts == null)
            {
                return NotFound();
            }

            var moviesCast = await _context.MoviesCasts.FindAsync(id);
            if (moviesCast == null)
            {
                return NotFound();
            }
            ViewData["ActorId"] = new SelectList(_context.Actors, "Id", "PersonName", moviesCast.ActorId);
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title", moviesCast.MovieId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name", moviesCast.RoleId);
            return View(moviesCast);
        }

        // POST: MoviesCasts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MovieId,ActorId,RoleId")] MoviesCast moviesCast)
        {
            if (id != moviesCast.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moviesCast);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoviesCastExists(moviesCast.Id))
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
            ViewData["ActorId"] = new SelectList(_context.Actors, "Id", "PersonName", moviesCast.ActorId);
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title", moviesCast.MovieId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name", moviesCast.RoleId);
            return View(moviesCast);
        }

        // GET: MoviesCasts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MoviesCasts == null)
            {
                return NotFound();
            }

            var moviesCast = await _context.MoviesCasts
                .Include(m => m.Actor)
                .Include(m => m.Movie)
                .Include(m => m.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moviesCast == null)
            {
                return NotFound();
            }

            return View(moviesCast);
        }

        // POST: MoviesCasts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MoviesCasts == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MoviesCasts'  is null.");
            }
            var moviesCast = await _context.MoviesCasts.FindAsync(id);
            if (moviesCast != null)
            {
                _context.MoviesCasts.Remove(moviesCast);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoviesCastExists(int id)
        {
          return _context.MoviesCasts.Any(e => e.Id == id);
        }
    }
}

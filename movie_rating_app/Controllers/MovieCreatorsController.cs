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
    public class MovieCreatorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieCreatorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MovieCreators
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MovieCreators.Include(m => m.Creator).Include(m => m.Movie).Include(m => m.Role);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MovieCreators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MovieCreators == null)
            {
                return NotFound();
            }

            var movieCreator = await _context.MovieCreators
                .Include(m => m.Creator)
                .Include(m => m.Movie)
                .Include(m => m.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieCreator == null)
            {
                return NotFound();
            }

            return View(movieCreator);
        }

        // GET: MovieCreators/Create
        public IActionResult Create()
        {
            ViewData["CreatorId"] = new SelectList(_context.Creators, "Id", "Id");
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id");
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id");
            return View();
        }

        // POST: MovieCreators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MovieId,CreatorId,RoleId")] MovieCreator movieCreator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieCreator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreatorId"] = new SelectList(_context.Creators, "Id", "Id", movieCreator.CreatorId);
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", movieCreator.MovieId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", movieCreator.RoleId);
            return View(movieCreator);
        }

        // GET: MovieCreators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MovieCreators == null)
            {
                return NotFound();
            }

            var movieCreator = await _context.MovieCreators.FindAsync(id);
            if (movieCreator == null)
            {
                return NotFound();
            }
            ViewData["CreatorId"] = new SelectList(_context.Creators, "Id", "Id", movieCreator.CreatorId);
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", movieCreator.MovieId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", movieCreator.RoleId);
            return View(movieCreator);
        }

        // POST: MovieCreators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MovieId,CreatorId,RoleId")] MovieCreator movieCreator)
        {
            if (id != movieCreator.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieCreator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieCreatorExists(movieCreator.Id))
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
            ViewData["CreatorId"] = new SelectList(_context.Creators, "Id", "Id", movieCreator.CreatorId);
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", movieCreator.MovieId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", movieCreator.RoleId);
            return View(movieCreator);
        }

        // GET: MovieCreators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MovieCreators == null)
            {
                return NotFound();
            }

            var movieCreator = await _context.MovieCreators
                .Include(m => m.Creator)
                .Include(m => m.Movie)
                .Include(m => m.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieCreator == null)
            {
                return NotFound();
            }

            return View(movieCreator);
        }

        // POST: MovieCreators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MovieCreators == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MovieCreators'  is null.");
            }
            var movieCreator = await _context.MovieCreators.FindAsync(id);
            if (movieCreator != null)
            {
                _context.MovieCreators.Remove(movieCreator);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieCreatorExists(int id)
        {
          return _context.MovieCreators.Any(e => e.Id == id);
        }
    }
}

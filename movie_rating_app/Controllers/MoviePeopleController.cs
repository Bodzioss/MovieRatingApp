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
    public class MoviePeopleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviePeopleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MoviePeople
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MoviePeople.Include(m => m.Movie).Include(m => m.Person).Include(m => m.Role);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MoviePeople/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MoviePeople == null)
            {
                return NotFound();
            }

            var moviePerson = await _context.MoviePeople
                .Include(m => m.Movie)
                .Include(m => m.Person)
                .Include(m => m.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moviePerson == null)
            {
                return NotFound();
            }

            return View(moviePerson);
        }

        // GET: MoviePeople/Create
        public IActionResult Create()
        {
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id");
            ViewData["PersonId"] = new SelectList(_context.People, "Id", "Id");
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id");
            return View();
        }

        // POST: MoviePeople/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MovieId,PersonId,RoleId")] MoviePerson moviePerson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moviePerson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", moviePerson.MovieId);
            ViewData["PersonId"] = new SelectList(_context.People, "Id", "Id", moviePerson.PersonId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", moviePerson.RoleId);
            return View(moviePerson);
        }

        // GET: MoviePeople/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MoviePeople == null)
            {
                return NotFound();
            }

            var moviePerson = await _context.MoviePeople.FindAsync(id);
            if (moviePerson == null)
            {
                return NotFound();
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", moviePerson.MovieId);
            ViewData["PersonId"] = new SelectList(_context.People, "Id", "Id", moviePerson.PersonId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", moviePerson.RoleId);
            return View(moviePerson);
        }

        // POST: MoviePeople/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MovieId,PersonId,RoleId")] MoviePerson moviePerson)
        {
            if (id != moviePerson.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moviePerson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoviePersonExists(moviePerson.Id))
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
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", moviePerson.MovieId);
            ViewData["PersonId"] = new SelectList(_context.People, "Id", "Id", moviePerson.PersonId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", moviePerson.RoleId);
            return View(moviePerson);
        }

        // GET: MoviePeople/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MoviePeople == null)
            {
                return NotFound();
            }

            var moviePerson = await _context.MoviePeople
                .Include(m => m.Movie)
                .Include(m => m.Person)
                .Include(m => m.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moviePerson == null)
            {
                return NotFound();
            }

            return View(moviePerson);
        }

        // POST: MoviePeople/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MoviePeople == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MoviePeople'  is null.");
            }
            var moviePerson = await _context.MoviePeople.FindAsync(id);
            if (moviePerson != null)
            {
                _context.MoviePeople.Remove(moviePerson);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoviePersonExists(int id)
        {
          return _context.MoviePeople.Any(e => e.Id == id);
        }
    }
}

﻿using System;
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
        private readonly aspnetmovie_rating_appContext _context;

        public MoviesCastsController(aspnetmovie_rating_appContext context)
        {
            _context = context;
        }

        // GET: MoviesCasts
        public async Task<IActionResult> Index()
        {
            var aspnetmovie_rating_appContext = _context.MoviesCasts.Include(m => m.Actor);
            return View(await aspnetmovie_rating_appContext.ToListAsync());
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
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (moviesCast == null)
            {
                return NotFound();
            }

            return View(moviesCast);
        }

        // GET: MoviesCasts/Create
        public IActionResult Create()
        {
            ViewData["ActorId"] = new SelectList(_context.Actors, "Id", "Id");
            return View();
        }

        // POST: MoviesCasts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,ActorId")] MoviesCast moviesCast)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moviesCast);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActorId"] = new SelectList(_context.Actors, "Id", "Id", moviesCast.ActorId);
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
            ViewData["ActorId"] = new SelectList(_context.Actors, "Id", "Id", moviesCast.ActorId);
            return View(moviesCast);
        }

        // POST: MoviesCasts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,ActorId")] MoviesCast moviesCast)
        {
            if (id != moviesCast.MovieId)
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
                    if (!MoviesCastExists(moviesCast.MovieId))
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
            ViewData["ActorId"] = new SelectList(_context.Actors, "Id", "Id", moviesCast.ActorId);
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
                .FirstOrDefaultAsync(m => m.MovieId == id);
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
                return Problem("Entity set 'aspnetmovie_rating_appContext.MoviesCasts'  is null.");
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
          return _context.MoviesCasts.Any(e => e.MovieId == id);
        }
    }
}

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
    public class NationalitiesController : Controller
    {
        private readonly aspnetmovie_rating_appContext _context;

        public NationalitiesController(aspnetmovie_rating_appContext context)
        {
            _context = context;
        }

        // GET: Nationalities
        public async Task<IActionResult> Index()
        {
              return View(await _context.Nationalities.ToListAsync());
        }

        // GET: Nationalities/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Nationalities == null)
            {
                return NotFound();
            }

            var nationality = await _context.Nationalities
                .FirstOrDefaultAsync(m => m.Name == id);
            if (nationality == null)
            {
                return NotFound();
            }

            return View(nationality);
        }

        // GET: Nationalities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nationalities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] Nationality nationality)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nationality);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nationality);
        }

        // GET: Nationalities/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Nationalities == null)
            {
                return NotFound();
            }

            var nationality = await _context.Nationalities.FindAsync(id);
            if (nationality == null)
            {
                return NotFound();
            }
            return View(nationality);
        }

        // POST: Nationalities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name")] Nationality nationality)
        {
            if (id != nationality.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nationality);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NationalityExists(nationality.Name))
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
            return View(nationality);
        }

        // GET: Nationalities/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Nationalities == null)
            {
                return NotFound();
            }

            var nationality = await _context.Nationalities
                .FirstOrDefaultAsync(m => m.Name == id);
            if (nationality == null)
            {
                return NotFound();
            }

            return View(nationality);
        }

        // POST: Nationalities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Nationalities == null)
            {
                return Problem("Entity set 'aspnetmovie_rating_appContext.Nationalities'  is null.");
            }
            var nationality = await _context.Nationalities.FindAsync(id);
            if (nationality != null)
            {
                _context.Nationalities.Remove(nationality);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NationalityExists(string id)
        {
          return _context.Nationalities.Any(e => e.Name == id);
        }
    }
}

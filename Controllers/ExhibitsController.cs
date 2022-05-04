﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DM.Data.Entity;

namespace DM.Controllers
{
    public class ExhibitsController : Controller
    {
        private readonly DataDbContext _context;

        public ExhibitsController(DataDbContext context)
        {
            _context = context;
        }

        // GET: Exhibits
        /*public async Task<IActionResult> Index(string search, bool notUsed)
        {
            var exhibits = from e in _context.Exhibits
                           select e;
            if (!String.IsNullOrEmpty(search))
            {
                exhibits = exhibits.Where(s => s.Name.Contains(search));
            }
            return View(await exhibits.ToListAsync());
        }
        */

        public async Task<IActionResult> Index(string ExhibitEra, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<bool> genreQuery = from m in _context.Exhibits
                                          orderby m.Era
                                          select m.Era;

            var exhibits = from m in _context.Exhibits
                           select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                exhibits = exhibits.Where(s => s.Name.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(ExhibitEra))
            {
                exhibits = exhibits.Where(x => x.Era == Convert.ToBoolean(ExhibitEra));
            }

            var movieGenreVM = new Models.ExhibitEraViewModel
            {
                Era = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Exhibits = await exhibits.ToListAsync()
            };

            return View(movieGenreVM);
        }

        /*public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }
        */

        // GET: Exhibits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exhibit = await _context.Exhibits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exhibit == null)
            {
                return NotFound();
            }

            return View(exhibit);
        }

        // GET: Exhibits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Exhibits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Century,Era,Place,Cost,Discription,Image")] Exhibit exhibit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exhibit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exhibit);
        }

        // GET: Exhibits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exhibit = await _context.Exhibits.FindAsync(id);
            if (exhibit == null)
            {
                return NotFound();
            }
            return View(exhibit);
        }

        // POST: Exhibits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Century,Era,Place,Cost,Discription,Image")] Exhibit exhibit)
        {
            if (id != exhibit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exhibit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExhibitExists(exhibit.Id))
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
            return View(exhibit);
        }

        // GET: Exhibits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exhibit = await _context.Exhibits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exhibit == null)
            {
                return NotFound();
            }

            return View(exhibit);
        }

        // POST: Exhibits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exhibit = await _context.Exhibits.FindAsync(id);
            _context.Exhibits.Remove(exhibit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExhibitExists(int id)
        {
            return _context.Exhibits.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FitnesCentar.Data;

namespace FitnesCentar.Controllers
{
    public class ProgramCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProgramCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProgramCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProgramCategories.ToListAsync());
        }

        // GET: ProgramCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programCategory = await _context.ProgramCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (programCategory == null)
            {
                return NotFound();
            }

            return View(programCategory);
        }

        // GET: ProgramCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProgramCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,DateModified")] ProgramCategory programCategory)
        {
            programCategory.DateModified = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return View(programCategory);
            }
          
            _context.ProgramCategories.Add(programCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: ProgramCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programCategory = await _context.ProgramCategories.FindAsync(id);
            if (programCategory == null)
            {
                return NotFound();
            }
            return View(programCategory);
        }

        // POST: ProgramCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DateModified")] ProgramCategory programCategory)
        {
            if (id != programCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    programCategory.DateModified = DateTime.Now;
                    _context.ProgramCategories.Update(programCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgramCategoryExists(programCategory.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        programCategory.DateModified = DateTime.Now;
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(programCategory);
        }

        // GET: ProgramCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programCategory = await _context.ProgramCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (programCategory == null)
            {
                return NotFound();
            }

            return View(programCategory);
        }

        // POST: ProgramCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var programCategory = await _context.ProgramCategories.FindAsync(id);
            if (programCategory != null)
            {
                _context.ProgramCategories.Remove(programCategory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgramCategoryExists(int id)
        {
            return _context.ProgramCategories.Any(e => e.Id == id);
        }
    }
}

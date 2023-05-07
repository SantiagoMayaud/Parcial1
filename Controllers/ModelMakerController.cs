using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parcial1SM.Models;
using Parcial1SM.data;

namespace Parcial1SM.Controllers
{
    public class ModelMakerController : Controller
    {
        private readonly ModelMakerContext _context;

        public ModelMakerController(ModelMakerContext context)
        {
            _context = context;
        }

        // GET: ModelMaker
        public async Task<IActionResult> Index()
        {
            var modelMakerContext = _context.ModelMaker.Include(m => m.ModelKits);
            return View(await modelMakerContext.ToListAsync());
        }

        // GET: ModelMaker/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ModelMaker == null)
            {
                return NotFound();
            }

            var modelMaker = await _context.ModelMaker
                .Include(m => m.ModelKits)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modelMaker == null)
            {
                return NotFound();
            }

            return View(modelMaker);
        }

        // GET: ModelMaker/Create
        public IActionResult Create()
        {
            ViewData["ModelKitId"] = new SelectList(_context.Set<ModelKit>(), "Id", "Id");
            return View();
        }

        // POST: ModelMaker/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BrandName,ModelKitId")] ModelMaker modelMaker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modelMaker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModelKitId"] = new SelectList(_context.Set<ModelKit>(), "Id", "Id", modelMaker.ModelKits);
            return View(modelMaker);
        }

        // GET: ModelMaker/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ModelMaker == null)
            {
                return NotFound();
            }

            var modelMaker = await _context.ModelMaker.FindAsync(id);
            if (modelMaker == null)
            {
                return NotFound();
            }
            ViewData["ModelKitId"] = new SelectList(_context.Set<ModelKit>(), "Id", "Id", modelMaker.ModelKits);
            return View(modelMaker);
        }

        // POST: ModelMaker/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BrandName,ModelKitId")] ModelMaker modelMaker)
        {
            if (id != modelMaker.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modelMaker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModelMakerExists(modelMaker.Id))
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
            ViewData["ModelKitId"] = new SelectList(_context.Set<ModelKit>(), "Id", "Id", modelMaker.ModelKits);
            return View(modelMaker);
        }

        // GET: ModelMaker/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ModelMaker == null)
            {
                return NotFound();
            }

            var modelMaker = await _context.ModelMaker
                .Include(m => m.ModelKits)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modelMaker == null)
            {
                return NotFound();
            }

            return View(modelMaker);
        }

        // POST: ModelMaker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ModelMaker == null)
            {
                return Problem("Entity set 'ModelMakerContext.ModelMaker'  is null.");
            }
            var modelMaker = await _context.ModelMaker.FindAsync(id);
            if (modelMaker != null)
            {
                _context.ModelMaker.Remove(modelMaker);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModelMakerExists(int id)
        {
          return (_context.ModelMaker?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

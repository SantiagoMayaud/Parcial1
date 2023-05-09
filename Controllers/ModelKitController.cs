using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parcial1SM.Data;
using Parcial1SM.Models;
using Parcial1SM.ViewModels;

namespace Parcial1SM.Controllers
{
    public class ModelKitController : Controller
    {
        private readonly ModelKitContext _context;

        public ModelKitController(ModelKitContext context)
        {
            _context = context;
        }

        // GET: ModelKit
        public async Task<IActionResult> Index(string nameFilter)
        {
            var query = from ModelKit in _context.ModelKit select ModelKit;

            if (!string.IsNullOrEmpty(nameFilter))
            {
                query = query.Where(x => x.Name.Contains(nameFilter));
            }

            var model = new ModelKitViewModel();
            model.ModelKits = await query.ToListAsync();

            return _context.ModelKit != null ?
                        View(model) :
                        Problem("Entity set 'MenuContext.Menu'  is null.");
        }

        // GET: ModelKit/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ModelKit == null)
            {
                return NotFound();
            }

            var modelKit = await _context.ModelKit
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modelKit == null)
            {
                return NotFound();
            }

            return View(modelKit);
        }

        // GET: ModelKit/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ModelKit/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type,ModelMaker,Pieces,Finished")] ModelKit modelKit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modelKit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modelKit);
        }

        // GET: ModelKit/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ModelKit == null)
            {
                return NotFound();
            }

            var modelKit = await _context.ModelKit.FindAsync(id);
            if (modelKit == null)
            {
                return NotFound();
            }
            return View(modelKit);
        }

        // POST: ModelKit/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,ModelMaker,Pieces,Finished")] ModelKit modelKit)
        {
            if (id != modelKit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modelKit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModelKitExists(modelKit.Id))
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
            return View(modelKit);
        }

        // GET: ModelKit/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ModelKit == null)
            {
                return NotFound();
            }

            var modelKit = await _context.ModelKit
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modelKit == null)
            {
                return NotFound();
            }

            return View(modelKit);
        }

        // POST: ModelKit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ModelKit == null)
            {
                return Problem("Entity set 'ModelKitContext.ModelKit'  is null.");
            }
            var modelKit = await _context.ModelKit.FindAsync(id);
            if (modelKit != null)
            {
                _context.ModelKit.Remove(modelKit);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModelKitExists(int id)
        {
            return (_context.ModelKit?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

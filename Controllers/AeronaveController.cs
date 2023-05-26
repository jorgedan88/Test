using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoPrimerParcial.Data;
using ProyectoPrimerParcial.Models;

namespace ProyectoPrimerParcial2.Controllers
{
    public class AeronaveController : Controller
    {
        private readonly InstructorContext _context;

        public AeronaveController(InstructorContext context)
        {
            _context = context;
        }

        // GET: Aeronave
        public async Task<IActionResult> Index()
        {
              return _context.Aeronave != null ? 
                          View(await _context.Aeronave.ToListAsync()) :
                          Problem("Entity set 'InstructorContext.Aeronave'  is null.");
        }

        // GET: Aeronave/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Aeronave == null)
            {
                return NotFound();
            }

            var aeronave = await _context.Aeronave
                .FirstOrDefaultAsync(m => m.AeronaveId == id);
            if (aeronave == null)
            {
                return NotFound();
            }

            return View(aeronave);
        }

        // GET: Aeronave/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aeronave/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AeronaveId,TipoAeronave")] Aeronave aeronave)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aeronave);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aeronave);
        }

        // GET: Aeronave/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Aeronave == null)
            {
                return NotFound();
            }

            var aeronave = await _context.Aeronave.FindAsync(id);
            if (aeronave == null)
            {
                return NotFound();
            }
            return View(aeronave);
        }

        // POST: Aeronave/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AeronaveId,TipoAeronave")] Aeronave aeronave)
        {
            if (id != aeronave.AeronaveId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aeronave);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AeronaveExists(aeronave.AeronaveId))
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
            return View(aeronave);
        }

        // GET: Aeronave/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Aeronave == null)
            {
                return NotFound();
            }

            var aeronave = await _context.Aeronave
                .FirstOrDefaultAsync(m => m.AeronaveId == id);
            if (aeronave == null)
            {
                return NotFound();
            }

            return View(aeronave);
        }

        // POST: Aeronave/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Aeronave == null)
            {
                return Problem("Entity set 'InstructorContext.Aeronave'  is null.");
            }
            var aeronave = await _context.Aeronave.FindAsync(id);
            if (aeronave != null)
            {
                _context.Aeronave.Remove(aeronave);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AeronaveExists(int id)
        {
          return (_context.Aeronave?.Any(e => e.AeronaveId == id)).GetValueOrDefault();
        }
    }
}

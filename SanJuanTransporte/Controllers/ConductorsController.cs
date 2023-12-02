using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SanJuanTransporte.Context;
using SanJuanTransporte.Models;

namespace SanJuanTransporte.Controllers
{
    public class ConductorsController : Controller
    {
        private readonly MiContext _context;

        public ConductorsController(MiContext context)
        {
            _context = context;
        }

        // GET: Conductors
        public async Task<IActionResult> Index()
        {
              return _context.Conductor != null ? 
                          View(await _context.Conductor.ToListAsync()) :
                          Problem("Entity set 'MiContext.Conductor'  is null.");
        }

        // GET: Conductors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Conductor == null)
            {
                return NotFound();
            }

            var conductor = await _context.Conductor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conductor == null)
            {
                return NotFound();
            }

            return View(conductor);
        }

        // GET: Conductors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Conductors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CI,CodigoConstructor,Direccion,Email,NombreCompleto,NumeroLicencia,NumeroPlaca,Foto")] Conductor conductor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conductor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(conductor);
        }

        // GET: Conductors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Conductor == null)
            {
                return NotFound();
            }

            var conductor = await _context.Conductor.FindAsync(id);
            if (conductor == null)
            {
                return NotFound();
            }
            return View(conductor);
        }

        // POST: Conductors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CI,CodigoConstructor,Direccion,Email,NombreCompleto,NumeroLicencia,NumeroPlaca,Foto")] Conductor conductor)
        {
            if (id != conductor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conductor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConductorExists(conductor.Id))
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
            return View(conductor);
        }

        // GET: Conductors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Conductor == null)
            {
                return NotFound();
            }

            var conductor = await _context.Conductor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conductor == null)
            {
                return NotFound();
            }

            return View(conductor);
        }

        // POST: Conductors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Conductor == null)
            {
                return Problem("Entity set 'MiContext.Conductor'  is null.");
            }
            var conductor = await _context.Conductor.FindAsync(id);
            if (conductor != null)
            {
                _context.Conductor.Remove(conductor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConductorExists(int id)
        {
          return (_context.Conductor?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}

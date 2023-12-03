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
    public class PagoesController : Controller
    {
        private readonly MiContext _context;

        public PagoesController(MiContext context)
        {
            _context = context;
        }

        // GET: Pagoes
        public async Task<IActionResult> Index()
        {
            var miContext = _context.Pago.Include(p => p.Conductor).Include(p => p.Usuario);
            return View(await miContext.ToListAsync());
        }

        // GET: Pagoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Pago == null)
            {
                return NotFound();
            }

            var pago = await _context.Pago
                .Include(p => p.Conductor)
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pago == null)
            {
                return NotFound();
            }

            return View(pago);
        }

        // GET: Pagoes/Create
        public IActionResult Create()
        {
            ViewData["ConductorId"] = new SelectList(_context.Conductor, "Id", "CodigoConstructor");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email");
            return View();
        }

        // POST: Pagoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,Numero,Detalle,Monto,ConductorId,UsuarioId")] Pago pago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConductorId"] = new SelectList(_context.Conductor, "Id", "CodigoConstructor", pago.ConductorId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email", pago.UsuarioId);
            return View(pago);
        }

        // GET: Pagoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Pago == null)
            {
                return NotFound();
            }

            var pago = await _context.Pago.FindAsync(id);
            if (pago == null)
            {
                return NotFound();
            }
            ViewData["ConductorId"] = new SelectList(_context.Conductor, "Id", "CodigoConstructor", pago.ConductorId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email", pago.UsuarioId);
            return View(pago);
        }

        // POST: Pagoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Fecha,Numero,Detalle,Monto,ConductorId,UsuarioId")] Pago pago)
        {
            if (id != pago.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagoExists(pago.Id))
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
            ViewData["ConductorId"] = new SelectList(_context.Conductor, "Id", "CodigoConstructor", pago.ConductorId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email", pago.UsuarioId);
            return View(pago);
        }

        // GET: Pagoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Pago == null)
            {
                return NotFound();
            }

            var pago = await _context.Pago
                .Include(p => p.Conductor)
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pago == null)
            {
                return NotFound();
            }

            return View(pago);
        }

        // POST: Pagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Pago == null)
            {
                return Problem("Entity set 'MiContext.Pago_1'  is null.");
            }
            var pago = await _context.Pago.FindAsync(id);
            if (pago != null)
            {
                _context.Pago.Remove(pago);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagoExists(string id)
        {
          return (_context.Pago?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

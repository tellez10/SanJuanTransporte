using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SanJuanTransporte.Context;
using SanJuanTransporte.Models;
using SanJuanTransporte.Services;


namespace SanJuanTransporte.Controllers
{
    public class PagoesController : Controller
    {
        private readonly MiContext _context;
        private readonly ReciboPdfService _reciboPdfService;

        public PagoesController(MiContext context , ReciboPdfService reciboPdfService)
        {
            _context = context;
            _reciboPdfService = reciboPdfService;
        }



        // GET: Pagoes
        public async Task<IActionResult> Index()
        {
            var miContext = _context.Pagos.Include(p => p.Conductor).Include(p => p.Usuario);
            return View(await miContext.ToListAsync());
        }

        // GET: Pagoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pagos == null)
            {
                return NotFound();
            }

            var pago = await _context.Pagos
                .Include(p => p.Conductor)
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.PagoId == id);
            if (pago == null)
            {
                return NotFound();
            }

            return View(pago);
        }

        // GET: Pagoes/Create
        public IActionResult Create()
        {
            ViewData["ConductorId"] = new SelectList(_context.Conductor, "ConductorId", "NombreCompleto");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "NombreCompleto");
            return View();
        }

        // POST: Pagoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PagoId,Monto,Detalle,FechaPago,Numero,Mes,Anio,ConductorId,UsuarioId")] Pago pago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConductorId"] = new SelectList(_context.Conductor, "ConductorId", "NombreCompleto", pago.ConductorId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "NombreCompleto", pago.UsuarioId);
            return View(pago);
        }

        // GET: Pagoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pagos == null)
            {
                return NotFound();
            }

            var pago = await _context.Pagos.FindAsync(id);
            if (pago == null)
            {
                return NotFound();
            }
            ViewData["ConductorId"] = new SelectList(_context.Conductor, "ConductorId", "NombreCompleto", pago.ConductorId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "NombreCompleto", pago.UsuarioId);
            return View(pago);
        }

        // POST: Pagoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PagoId,Monto,Detalle,FechaPago,Numero,Mes,Anio,ConductorId,UsuarioId")] Pago pago)
        {
            if (id != pago.PagoId)
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
                    if (!PagoExists(pago.PagoId))
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
            ViewData["ConductorId"] = new SelectList(_context.Conductor, "ConductorId", "NombreCompleto", pago.ConductorId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "NombreCompleto", pago.UsuarioId);
            return View(pago);
        }

        // GET: Pagoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pagos == null)
            {
                return NotFound();
            }

            var pago = await _context.Pagos
                .Include(p => p.Conductor)
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.PagoId == id);
            if (pago == null)
            {
                return NotFound();
            }

            return View(pago);
        }

        // POST: Pagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pagos == null)
            {
                return Problem("Entity set 'MiContext.Pagos'  is null.");
            }
            var pago = await _context.Pagos.FindAsync(id);
            if (pago != null)
            {
                _context.Pagos.Remove(pago);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagoExists(int id)
        {
          return (_context.Pagos?.Any(e => e.PagoId == id)).GetValueOrDefault();
        }





        public async Task<IActionResult> GenerarRecibo(int pagoId)
        {
            var pago = await _context.Pagos.FindAsync(pagoId);

            if (pago == null)
            {
                return NotFound();
            }
            // Ejemplo hipotético
            var pdfBytes = await _reciboPdfService.GenerarReciboPdfAsync(pago, "firmaConductor", "firmaEncargado");

        

            // Pasa el arreglo de bytes como modelo a la vista
            return View("Recibo", pdfBytes);
        }


       
       

    }
}

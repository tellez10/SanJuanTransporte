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
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ConductorsController(MiContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            _hostingEnvironment = hostingEnvironment;
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
                .FirstOrDefaultAsync(m => m.ConductorId == id);
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
public async Task<IActionResult> Create([Bind("ConductorId,CI,Direccion,Email,NombreCompleto,NumeroLicencia,NumeroPlaca,Foto,FotoFile")] Conductor conductor)
{
    if (ModelState.IsValid)
    {
        // Verificar si se ha cargado un archivo
        if (conductor.FotoFile != null && conductor.FotoFile.Length > 0)
        {
            // Obtener la extensión del archivo
            var fileExtension = Path.GetExtension(conductor.FotoFile.FileName).ToLowerInvariant();

            // Verificar si la extensión es válida (puedes personalizar según tus requisitos)
            if (fileExtension != ".jpg" && fileExtension != ".jpeg" && fileExtension != ".png")
            {
                ModelState.AddModelError("FotoFile", "Solo se permiten archivos de imagen (jpg, jpeg, png).");
                return View(conductor);
            }

            // Obtener la ruta donde se almacenará el archivo
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + conductor.FotoFile.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            // Guardar el archivo en el servidor
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await conductor.FotoFile.CopyToAsync(fileStream);
            }

            // Actualizar la propiedad 'Foto' con el nombre único del archivo
            conductor.Foto = uniqueFileName;
        }

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
        public async Task<IActionResult> Edit(int id, [Bind("ConductorId,CI,Direccion,Email,NombreCompleto,NumeroLicencia,NumeroPlaca,Foto")] Conductor conductor)
        {
            if (id != conductor.ConductorId)
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
                    if (!ConductorExists(conductor.ConductorId))
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
                .FirstOrDefaultAsync(m => m.ConductorId == id);
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
          return (_context.Conductor?.Any(e => e.ConductorId == id)).GetValueOrDefault();
        }

        [HttpGet]
        [Route("conductores/search", Name = "SearchConductors")]
        public async Task<IActionResult> Search(string searchTerm)
        {
            // Realiza la lógica de búsqueda utilizando el término de búsqueda
            var conductores = await _context.Conductor
     .Where(c => c.NombreCompleto.Contains(searchTerm))
     .ToListAsync();


            return View("Index", conductores);
        }



    }
}

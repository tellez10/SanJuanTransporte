using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SanJuanTransporte.Context;
using SanJuanTransporte.Models;
using System.Security.Claims;

namespace SanJuanTransporte.Controllers
{
    public class ReporteController : Controller
    {
        private MiContext _miContext;
        public ReporteController(MiContext miContext)
        {
            _miContext = miContext;
        }

        public IActionResult Index()
        {
            int idUsuario = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var usuario = _miContext.Usuarios
                .Where(x => x.UsuarioId == idUsuario)
                .Include(x => x.Pagos)
                .FirstOrDefault();


            return View(usuario);
        }
    }
}

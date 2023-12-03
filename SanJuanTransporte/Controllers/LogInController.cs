using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SanJuanTransporte.Context;

namespace SanJuanTransporte.Controllers
{
    public class LogInController : Controller
    {
        //Inyeccion de dependencias
        private MiContext _context;
        public LogInController(MiContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        //Consulta a la base de datos
        public async Task <IActionResult> Login(string correo , string password)
        {
            var usuario = await _context.Usuarios
                                    .Where(x => x.Email == correo && x.Password == password)
                                    .FirstOrDefaultAsync();
            if (usuario == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["LoginError"] = "Cuenta o Contraseña incorrecta";
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Logout()
        {

            return RedirectToAction("Index", "Login");
        }
    }
}

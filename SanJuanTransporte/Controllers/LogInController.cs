using Microsoft.AspNetCore.Mvc;

namespace SanJuanTransporte.Controllers
{
    public class LogInController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        //Consulta a la base de datos
        public async Task <IActionResult> Login(string email , string password)
        {
            return RedirectToAction("Index");
        }

    }
}

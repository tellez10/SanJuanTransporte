using Microsoft.AspNetCore.Mvc;

namespace SanJuanTransporte.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

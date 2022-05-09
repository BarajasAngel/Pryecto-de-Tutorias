using Microsoft.AspNetCore.Mvc;

namespace Titulacion.Controllers
{
    public class LandingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

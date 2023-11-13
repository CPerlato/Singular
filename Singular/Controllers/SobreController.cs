using Microsoft.AspNetCore.Mvc;

namespace Singular.Controllers
{
    public class SobreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

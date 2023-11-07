using Microsoft.AspNetCore.Mvc;

namespace Singular.Controllers
{
    public class ContaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

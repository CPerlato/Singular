using Microsoft.AspNetCore.Mvc;

namespace Singular.Controllers
{
    public class RankingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

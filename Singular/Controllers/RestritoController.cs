using Microsoft.AspNetCore.Mvc;
using Singular.Filtros;

namespace Singular.Controllers
{
    [PaginaParaUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}


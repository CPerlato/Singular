using Microsoft.AspNetCore.Mvc;
using Singular.Filtros;
using Singular.Models;
using Singular.Repositorio;

namespace Singular.Controllers
{
    [PaginaRestritaAdmin]

    public class AlunoController : Controller
    {
        private readonly IAlunoRepositorio _alunoRepositorio;
        public AlunoController(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;            
        }

        public IActionResult Index()
        {
            List<AlunoModel> alunos = _alunoRepositorio.BuscarTodos();

            return View(alunos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar()
        {
            return View();
        }

        public IActionResult ApagarConfirmacao()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(AlunoModel aluno)
        {
            _alunoRepositorio.Adicionar(aluno);

            return RedirectToAction("Index");
        }
    }
}

//using Microsoft.AspNetCore.Mvc;
//using Singular.Filtros;
//using Singular.Models;
//using Singular.Repositorio;

//namespace Singular.Controllers
//{
//    [PaginaRestritaAdmin]

//    public class AlunoController : Controller
//    {
//        private readonly IAlunoRepositorio _alunoRepositorio;
//        public AlunoController(IAlunoRepositorio alunoRepositorio)
//        {
//            _alunoRepositorio = alunoRepositorio;            
//        }

//        public IActionResult Index()
//        {
//            List<AlunoModel> alunos = _alunoRepositorio.BuscarTodos();

//            return View(alunos);
//        }

//        public IActionResult Criar()
//        {
//            return View();
//        }

//        public IActionResult Editar(int id)
//        {
//            AlunoModel aluno = _alunoRepositorio.ListarPorId(id);
//            return View(aluno);
//        }

//        public IActionResult ApagarConfirmacao(int id)
//        {
//            AlunoModel aluno = _alunoRepositorio.ListarPorId(id);
//            return View(aluno);
//        }
        
//        public IActionResult Apagar(int id)
//        {
//            try
//            {
//                bool apagado = _alunoRepositorio.Apagar(id);

//                if (apagado) TempData["MensagemSucesso"] = "Usuário apagado com sucesso"; else TempData["MensagemErro"] = "Ops, não conseguimos apagar este usuário";
//                return RedirectToAction("Index");

//            }
//            catch (Exception erro)
//            {
//                TempData["MensagemErro"] = $"Ops, não conseguimos apagar este usuário. Detalhe do erro {erro.Message}";
//                return RedirectToAction("Index");
//            }
//        }

//        [HttpPost]
//        public IActionResult Criar(AlunoModel aluno)
//        {
//            _alunoRepositorio.Adicionar(aluno);

//            return RedirectToAction("Index");
//        }

//        [HttpPost]

//        public IActionResult Alterar(AlunoModel aluno)
//        {
//            _alunoRepositorio.Atualizar(aluno);
            
//            return RedirectToAction("Index");

//        }
//    }
//}

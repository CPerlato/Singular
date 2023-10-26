using Microsoft.AspNetCore.Mvc;
using Singular.Models;
using Singular.Repositorio;

namespace Singular.Controllers
{
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

        public IActionResult Apagar()
        {
            return View();
        }

        public IActionResult ApagarConfirmacao()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            AlunoModel aluno = _alunoRepositorio.BuscarPorId(id);
            return View(aluno);
        }

        [HttpPost]
        public IActionResult Criar(AlunoModel aluno)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    aluno = _alunoRepositorio.Adicionar(aluno);
                    TempData["MensagemSucesso"] = "Aluno cadastrado com sucesso";
                    return RedirectToAction("Index", "Aluno");
                }
                return View(aluno);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível cadastrar o aluno. Detalhes do erro: {erro}";
                return RedirectToAction("Index", "Aluno");
            }
        }

        [HttpPost]
        public IActionResult Editar(AlunoModel aluno)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    aluno = new AlunoModel()
                    {
                        Id = aluno.Id,
                        Nome = aluno.Nome,
                        CPF = aluno.CPF,
                        Celular = aluno.Celular,
                        Endereco = aluno.Endereco,
                        NomeDoResponsavel = aluno.NomeDoResponsavel,
                        TelefoneDoResponsavel = aluno.TelefoneDoResponsavel
                    };
                    aluno = _alunoRepositorio.Atualizar(aluno);

                    TempData["MensagemDeSucesso"] = "Aluno atualizado com sucesso";
                    return RedirectToAction("Index", "Aluno");

                }
                return View(aluno);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar os dados do aluno\nDetalhe do erro: {erro.Message}";
                return RedirectToAction("Index","Aluno");
            }
        }
    }
}

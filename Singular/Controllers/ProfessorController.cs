using Microsoft.AspNetCore.Mvc;
using Singular.Models;
using Singular.Repositorio;

namespace Singular.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly IProfessorRepositorio _professorRepositorio;
        public ProfessorController (IProfessorRepositorio professorRepositorio)
        {
            _professorRepositorio = professorRepositorio;
        }
        public IActionResult Index()
        {
            List<ProfessorModel> professores = _professorRepositorio.BuscarTodos();
            return View(professores);
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
            ProfessorModel professor = _professorRepositorio.BuscarPorId(id);
            return View(professor);
        }

        [HttpPost]
        public IActionResult Criar(ProfessorModel professor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    professor = _professorRepositorio.Adicionar(professor);
                    TempData["MensagemSucesso"] = "Aluno cadastrado com sucesso";
                    return RedirectToAction("Index", "Professor");
                }
                return View(professor);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível cadastrar o aluno. Detalhes do erro: {erro}";
                return RedirectToAction("Index", "Professor");
            }
        }

        [HttpPost]
        public IActionResult Editar(ProfessorModel professor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    professor = new ProfessorModel()
                    {
                        Id = professor.Id,
                        Nome = professor.Nome,
                        CPF = professor.CPF,
                        Celular = professor.Celular,
                        Endereco = professor.Endereco,
                        Materia = professor.Materia,
                        //TelefoneDoResponsavel = aluno.TelefoneDoResponsavel
                    };
                    professor = _professorRepositorio.Atualizar(professor);

                    TempData["MensagemDeSucesso"] = "Aluno atualizado com sucesso";
                    return RedirectToAction("Index", "Professor");

                }
                return View(professor);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar os dados do aluno\nDetalhe do erro: {erro.Message}";
                return RedirectToAction("Index", "Professor");
            }
        }
    }
}



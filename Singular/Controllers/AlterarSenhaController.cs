using Microsoft.AspNetCore.Mvc;
using Singular.Helper;
using Singular.Models;
using Singular.Repositorio;

namespace Singular.Controllers
{
    public class AlterarSenhaController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sesssao;
        public AlterarSenhaController(IUsuarioRepositorio usuarioRepositorio,
                                      ISessao sessao) 
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sesssao = sessao;  
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Alterar(AlterarSenhaModel alterarSenhaModel)
        {
            try
            {
                UsuarioModel usuarioLogado = _sesssao.BuscarSessaoUsuario();
                alterarSenhaModel.Id = usuarioLogado.Id;

                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.AlterarSenha(alterarSenhaModel);
                    TempData["MensagemSucesso"] = "Senha alterada com sucesso";
                    return View("Index", alterarSenhaModel);
                }
              
                return View("Index", alterarSenhaModel);
            
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos alterar sua senha.";
                return View("Index", alterarSenhaModel);
            }
        }
    }
}

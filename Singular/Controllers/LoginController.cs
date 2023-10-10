using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Singular.Helper;
using Singular.Models;
using Singular.Repositorio;
using System.Security.Claims;
using Singular.Models;

namespace Singular.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;
        private readonly IEmail _email;

        public LoginController(IUsuarioRepositorio usuarioRepositorio,
                                ISessao sessao,
                                IEmail email)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
            _email = email;
        }

        public IActionResult Index()
        {
            // Se já houver sessãoa aberta, redirecionar para a Home
            if (_sessao.BuscarSessaoUsuario() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult RedefinirSenha()
        {
            return View();
        }
        public IActionResult Sair()
        {
            _sessao.RemoverSessaoUsuario();

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);

                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessaoUsuario(usuario);
                            return RedirectToAction("Index", "Home");

                        }
                        TempData["MensagemErro"] = "Login e/ou Senha do usuário invalida(o)";
                    }

                }

                return View("Index");

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos encontrar seu usuário.\nDetalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        [HttpPost] 
        public IActionResult EnviarLinkParaRedefinirSenha(RedefinirSenhaModel redefinirSenhaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorEmailELogin(redefinirSenhaModel.Email, redefinirSenhaModel.Login);

                    if (usuario != null)
                    {
                        string novaSenha = usuario.GerarNovaSenha();
                        string mensagem = $"Sua nova senha é: {novaSenha}";

                        bool emailEnviado = _email.Enviar(usuario.Email, "Singular - Redefinição de Senha", mensagem);

                        if (emailEnviado)
                        {
                            _usuarioRepositorio.Atualizar(usuario);
                            TempData["MensagemSucesso"] = "Enviamos para seu e-mail cadastrado uma nova senha.";
                        }
                        else
                        {
                            TempData["MensagemErro"] = "Não conseguimos enviar o email.\n Por favor tente novamente";
                        }

                        return RedirectToAction("Index", "Login");
                    }
                    TempData["MensagemErro"] = "Não conseguimos redefinir sua senha.\n Por favor verifique os dados informados";

                }

                return View("Index");

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos Redefinir sua senha.\nDetalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
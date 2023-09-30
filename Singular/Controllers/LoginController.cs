using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Singular.Models;
using System.Security.Claims;

namespace Singular.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Entrar(LoginModel dados)
        {
            try
            {
                //aqui vai um IF que verifica se o Nome de usuario e senha é correto
                //se for correto executa essa parte aqui para logar
                //se nao for pode abrir um throw new Exception("Login e senha invalido")
                throw new Exception("Login e senha invalido");
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, "aqui vai a variavel do usuario que veio da tela"));
                claims.Add(new Claim(ClaimTypes.Sid, "aqui vai o ID dele que esta no banco de dados salvo"));




                var userIdentity = new ClaimsIdentity(claims, "Acesso");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync("CookieAuthentication", principal, new AuthenticationProperties
                {
                    IsPersistent = true

                }); ;

                //Just redirect to our index after logging in. 
                return Redirect("/");


            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Login invalido, tente novamente, detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");

            }


        }
        public async Task<IActionResult> Logoff()
        {
            await HttpContext.SignOutAsync("CookieAuthentication");
            ViewData["ReturnUrl"] = "/";
            return Redirect("/Login/Index");
        }
    }



}
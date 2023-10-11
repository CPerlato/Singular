using System.ComponentModel.DataAnnotations;

namespace Singular.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite o nome do usuário")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite sua senha")]
        public String Senha { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Singular.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite o login")]
        public string? Email { get; set; }
     
        [Required(ErrorMessage = "Digite sua senha")]
        public string? Senha { get; set; }
    }
}

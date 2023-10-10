using System.ComponentModel.DataAnnotations;

namespace Singular.Models
{
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage = "Digite o nome do usuário")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite o e-mail")]
        public String Email { get; set; }
    }
}

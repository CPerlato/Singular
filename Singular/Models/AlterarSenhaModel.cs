using System.ComponentModel.DataAnnotations;

namespace Singular.Models
{
    public class AlterarSenhaModel
    {
        
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Digite sua senha atual.")]
        public string SenhaAtual { get; set; }

        [Required(ErrorMessage = "Digite a nova senha.")]
        public string NovaSenha { get; set; }

        [Required(ErrorMessage = "Confirme a nova senha.")]
        [Compare("NovaSenha",ErrorMessage = "Senhas não conferem")]
        public string ConfirmarSenha { get; set; }

    }
}

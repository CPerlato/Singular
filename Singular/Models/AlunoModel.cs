using System.ComponentModel.DataAnnotations;

namespace Singular.Models
{
    public class AlunoModel
    {
        public int Id { get; set; }

        public string? Ra { get; set; }

        [Required(ErrorMessage = "Digite o nome do aluno")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o CPF do aluno")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Digite o celular do aluno")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Digite a data de nascimento do aluno")]
        public string DataNascimento { get; set; }

        [Required(ErrorMessage = "Digite o endereço do aluno")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Digite o nome do responsável do aluno")]
        public string NomeDoResponsavel { get; set; }

        [Required(ErrorMessage = "Digite o telefone do responsável do aluno")]
        public string TelefoneDoResponsavel { get; set; }
    }
}

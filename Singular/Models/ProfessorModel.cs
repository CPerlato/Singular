using System.ComponentModel.DataAnnotations;

namespace Singular.Models
{
    public class ProfessorModel
    {
        public int Id { get; set; }

        public string? Ra { get; set; }

        [Required(ErrorMessage = "Digite o nome do professor")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o CPF do professor")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Digite o celular do professor")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Digite a data de nascimento do professor")]
        public string DataNascimento { get; set; }

        [Required(ErrorMessage = "Digite o endereço do professor")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Digite a matéria do professor")]
        public string Materia { get; set; }

    }
}

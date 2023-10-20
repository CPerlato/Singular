namespace Singular.Models
{
    public class AlunoModel
    {
        public int Id {  get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Celular { get; set; }
        public string DataNascimento { get; set; }
        public string Endereco { get; set; }
        public string NomeDoResponsavel { get; set;}
        public string TelefoneDoResponsavel { get; set; }
    }
}

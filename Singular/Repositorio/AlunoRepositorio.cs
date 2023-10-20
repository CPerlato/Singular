using Singular.Data;
using Singular.Models;

namespace Singular.Repositorio
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public AlunoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<AlunoModel> BuscarTodos()
        {
            return _bancoContext.Alunos.ToList();
        }

        public AlunoModel Adicionar(AlunoModel aluno)
        {
            _bancoContext.Alunos.Add(aluno);
            _bancoContext.SaveChanges();

            return aluno;
        }


    }
}

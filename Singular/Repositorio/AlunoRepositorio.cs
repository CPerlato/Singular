using Singular.Data;
using Singular.Models;

namespace Singular.Repositorio
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly BancoContext _context;
        public AlunoRepositorio(BancoContext bancoContext)
        {
            this._context = bancoContext;
        }

        public AlunoModel BuscarPorId(int id)
        {
            return _context.Alunos.FirstOrDefault(x => x.Id == id);
        }

        public List<AlunoModel> BuscarTodos()
        {
            return _context.Alunos.ToList();
        }

        public AlunoModel Adicionar(AlunoModel aluno)
        {
            _context.Alunos.Add(aluno);
            _context.SaveChanges();
            return aluno;
        }

        public AlunoModel Atualizar(AlunoModel aluno)
        {
            AlunoModel alunoDB = BuscarPorId(aluno.Id);

            if (alunoDB == null) throw new Exception("Houve um erro na atualização do aluno");

            alunoDB.Nome = aluno.Nome;
            alunoDB.CPF = aluno.CPF;
            alunoDB.Celular = aluno.Celular;
            alunoDB.Endereco = aluno.Endereco;
            alunoDB.NomeDoResponsavel = aluno.NomeDoResponsavel;
            alunoDB.TelefoneDoResponsavel = aluno.TelefoneDoResponsavel;

            _context.Alunos.Update(alunoDB);
            _context.SaveChanges();

            return alunoDB;
        }
    }
}


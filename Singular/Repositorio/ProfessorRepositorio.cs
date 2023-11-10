using Singular.Data;
using Singular.Models;

namespace Singular.Repositorio
{
    public class ProfessorRepositorio : IProfessorRepositorio
    {
        private readonly BancoContext _context;
        public ProfessorRepositorio(BancoContext bancoContext)
        {
            this._context = bancoContext;
        }

        public ProfessorModel BuscarPorId(int id)
        {
            return _context.Professores.FirstOrDefault(x => x.Id == id);
        }

        public List<ProfessorModel> BuscarTodos()
        {
            return _context.Professores.ToList();
        }

        public ProfessorModel Adicionar(ProfessorModel professor)
        {
            _context.Professores.Add(professor);
            _context.SaveChanges();
            return professor;
        }

        public ProfessorModel Atualizar(ProfessorModel professor)
        {
            ProfessorModel professorDB = BuscarPorId(professor.Id);

            if (professorDB == null) throw new Exception("Houve um erro na atualização do aluno");

            professorDB.Nome = professor.Nome;
            professorDB.CPF = professor.CPF;
            professorDB.Celular = professor.Celular;
            professorDB.Endereco = professor.Endereco;
            professorDB.Materia = professor.Materia;
            //professorDB.TelefoneDoResponsavel = professor.TelefoneDoResponsavel;

            _context.Professores.Update(professorDB);
            _context.SaveChanges();

            return professorDB;
        }
    }
}

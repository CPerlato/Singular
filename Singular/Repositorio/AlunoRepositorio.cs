//using Singular.Data;
//using Singular.Models;
//using Microsoft.EntityFrameworkCore;

//namespace Singular.Repositorio
//{
//    public class AlunoRepositorio : IAlunoRepositorio
//    {
//        private readonly BancoContext _context;
//        public AlunoRepositorio(BancoContext bancoContext)
//        {
//            this._context = bancoContext;
//        }

//        public UsuarioModel BuscarPorId(int id)
//        {
//            return _context.Usuarios.FirstOrDefault(x => x.Id == id);
//        }
//        public UsuarioModel BuscarPorLogin(string login)
//        {
//            return _context.Usuarios.FirstOrDefault(x => x.Login.ToLower() == login.ToLower());
//        }
//        public UsuarioModel BuscarPorEmailELogin(string email, string login)
//        {
//            return _context.Usuarios.FirstOrDefault(x => x.Email.ToLower() == email.ToLower() && x.Login.ToLower() == login.ToLower());
//        }

//        public List<AlunoModel> BuscarTodos()
//        {
//            return _context.Alunos.ToList();
//        }

//        public AlunoModel ListarPorId(int id)
//        {
//            return _context.Alunos.FirstOrDefault(x => x.Id == id);
//        }

//        public AlunoModel Adicionar(AlunoModel aluno)
//        {
//            if (_context.Alunos.Any(u => u.Nome == aluno.Nome && u.Id != aluno.Id))
//            {
//                throw new Exception("Já existe um usuário com o mesmo nome.");
//            }

//            _context.Alunos.Add(aluno);
//            _context.SaveChanges();
//            return aluno;
//        }

//        public AlunoModel Atualizar(AlunoModel aluno)
//        {
//            AlunoModel alunoDB = ListarPorId(aluno.Id);

//            if (alunoDB == null) throw new Exception("Houve um erro na atualização de usuário");

//            if (_context.Alunos.Any(u => u.Nome == aluno.Nome && u.Id != aluno.Id))
//            {
//                throw new Exception("Já existe um usuário com o mesmo nome.");
//            }

//            alunoDB.Nome = aluno.Nome;
//            alunoDB.CPF = aluno.CPF;
//            alunoDB.Celular = aluno.Celular;
//            alunoDB.Endereco = aluno.Endereco;
//            alunoDB.DataNascimento = aluno.DataNascimento;
//            alunoDB.NomeDoResponsavel = aluno.NomeDoResponsavel;
//            alunoDB.TelefoneDoResponsavel = aluno.TelefoneDoResponsavel;

//            _context.Alunos.Update(alunoDB);
//            _context.SaveChanges();

//            return alunoDB;
//        }

//        public UsuarioModel AlterarSenha(AlterarSenhaModel alterarSenhaModel)
//        {
//            UsuarioModel usuarioDB = BuscarPorId(alterarSenhaModel.Id);

//            if (usuarioDB == null) throw new Exception("Houve um erro, usuário não encontrado");

//            if (!usuarioDB.SenhaValida(alterarSenhaModel.SenhaAtual)) throw new Exception("Senha Atual não confere");

//            if (usuarioDB.SenhaValida(alterarSenhaModel.NovaSenha)) throw new Exception("Nova senha deve ser diferente da senha atual");

//            usuarioDB.SetNovaSenha(alterarSenhaModel.NovaSenha);
//            _context.SaveChanges();

//            usuarioDB.DataAtualizacao = DateTime.Now;

//            return usuarioDB;
//        }

//        public bool Apagar(int id)
//        {
//            AlunoModel alunoDB = ListarPorId(id);

//            if (alunoDB == null) throw new Exception("Houve um erro na deleção de usuário");

//            _context.Alunos.Remove(alunoDB);
//            _context.SaveChanges();

//            return true;
//        }
//    }
//}


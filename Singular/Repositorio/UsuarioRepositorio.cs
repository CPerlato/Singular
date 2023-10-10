using Microsoft.EntityFrameworkCore;
using Singular.Data;
using Singular.Models;
using Singular.Repositorio;

namespace Singular.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _context;
        public UsuarioRepositorio(BancoContext bancoContext)
        {
            this._context = bancoContext;
        }

        public UsuarioModel BuscarPorId(int id)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Id == id);
        }
        public UsuarioModel BuscarPorLogin(string login)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Login.ToLower() == login.ToLower());
        }
        public UsuarioModel BuscarPorEmailELogin(string email, string login)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Email.ToLower() == email.ToLower() && x.Login.ToLower() == login.ToLower());
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _context.Usuarios.ToList();
        }
        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            usuario.SetSenhaHash();
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = BuscarPorId(usuario.Id);

            if (usuarioDB == null) throw new Exception("Houve um erro na atualização de usuário");

            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.DataAtualizacao = DateTime.Now;

            _context.Usuarios.Update(usuarioDB);
            _context.SaveChanges();

            return usuarioDB;
        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDB = BuscarPorId(id);

            if (usuarioDB == null) throw new Exception("Houve um erro na deleção de usuário");

            _context.Usuarios.Remove(usuarioDB);
            _context.SaveChanges();

            return true;
        }
    }
}

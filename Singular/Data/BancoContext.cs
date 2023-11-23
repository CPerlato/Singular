using Microsoft.EntityFrameworkCore;
using Singular.Models;

namespace Singular.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<AlunoModel> Alunos { get; set; }
        public DbSet<ProfessorModel> Professores { get; set; }
        public DbSet<MediaModel> Medias { get; set; }


    }
}

using Microsoft.EntityFrameworkCore;
using Singular.Models;

namespace Singular.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) :
            base(options)
        {
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }

    }
}

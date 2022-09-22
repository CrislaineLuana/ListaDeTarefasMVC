using ListaDeTarefasMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ListaDeTarefasMVC.Data
{
    public class BancoDbContext : DbContext
    {
        public BancoDbContext(DbContextOptions<BancoDbContext> options) : base(options)
        {
        }

        public DbSet<TarefaModel> Tarefas { get; set; }
        public DbSet<UsuarioModel> Usuario  { get; set; }
    }
}

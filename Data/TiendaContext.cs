
using Microsoft.EntityFrameworkCore;
using TiendaVirtualReyes.Models;


namespace TiendaVirtualReyes.Data
{
    public class TiendaContext : DbContext
    {
        public TiendaContext(DbContextOptions<TiendaContext> options)
            : base(options)
        {
        }
        public DbSet<Producto> productos { get; set; }
        public DbSet<Categoria> categorias { get; set; }
        public DbSet<Usuario> usuarios { get; set; }

    }
}

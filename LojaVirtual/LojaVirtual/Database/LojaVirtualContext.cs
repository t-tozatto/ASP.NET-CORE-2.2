using LojaVirtual.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.Database
{
    public class LojaVirtualContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<NewsletterEmail> NewsletterEmail { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        public LojaVirtualContext(DbContextOptions<LojaVirtualContext> options) : base(options)
        {

        }        
    }
}

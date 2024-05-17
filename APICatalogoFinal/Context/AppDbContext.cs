using APICatalogoFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalogoFinal.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        // mapeamento objeto relacional
        public DbSet<Categoria>? Categorias { get; set; } // entidade: Categoria. Tabela: Categorias
        public DbSet<Produto>? Produtos { get; set; }

    }
}
 
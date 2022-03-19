using MacorattiMVC.Domain.Entitites;
using Microsoft.EntityFrameworkCore;

namespace MacorratiMVC.Infra.data.Context
{
    public class BancoContexto : DbContext
    {
        public BancoContexto(DbContextOptions<BancoContexto> options) : base(options)
        { }

        public DbSet<Category> Categorias { get; set; }
        public DbSet<Product> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BancoContexto).Assembly);
        }
    }
}

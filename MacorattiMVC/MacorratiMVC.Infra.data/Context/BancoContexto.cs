using MacorattiMVC.Domain.Entitites;
using MacorratiMVC.Infra.data.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MacorratiMVC.Infra.data.Context
{
    public class BancoContexto : IdentityDbContext<AplicacaoDoUsuario>
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

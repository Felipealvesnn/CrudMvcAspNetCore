using MacorattiMVC.Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MacorratiMVC.Infra.data.EntitiesConfiguration
{
    public class CategoriesConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.HasData(
                new Category(1, "Material escolar"),
                new Category(2, "Eletronicos"),
                new Category(3, "Acessorios")


                );

        }
    }
}

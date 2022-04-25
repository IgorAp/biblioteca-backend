using BibliotecaBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BibliotecaBackend.Infra.Data.WriteModel.Mappings
{
    public class LivroAutorMap : IEntityTypeConfiguration<LivroAutor>
    {
        public void Configure(EntityTypeBuilder<LivroAutor> builder)
        {
            builder.ToTable("LivroAutores");
            builder.HasKey("Id");

            builder.HasOne(la => la.Autor)
                .WithMany(a => a.LivrosAutor)
                .HasForeignKey(la => la.AutorId);

            builder.HasOne(la => la.Livro)
                .WithMany(l => l.AutoresLivro)
                .HasForeignKey(la => la.LivroId);

        }
    }
}

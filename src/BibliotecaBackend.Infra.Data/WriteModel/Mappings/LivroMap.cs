using BibliotecaBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBackend.Infra.Data.WriteModel.Mappings
{
    public class LivroMap : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livros");
            builder.HasKey("Id");

            builder.Property(x => x.Titulo)
                .IsRequired()
                .HasColumnName("Titulo")
                .HasColumnType("varchar(100)");

            builder.Property(x => x.Foto)
                .IsRequired()
                .HasColumnName("Foto")
                .HasColumnType("varchar(255)");

            builder.HasOne(x => x.Editora)
                .WithMany(e => e.Livros)
                .HasForeignKey(x => x.EditoraId);
        }
    }
}

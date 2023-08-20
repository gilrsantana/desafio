using Livraria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Livraria.Context.Data.Mappings;

public class BookMap : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .HasColumnType("UNIQUEIDENTIFIER");

        builder.Property(x => x.Title)
               .IsRequired()
               .HasColumnType("VARCHAR(150)")
               .HasMaxLength(150);

        builder.Property(x => x.ISBN)
               .IsRequired()
               .HasColumnType("VARCHAR(13)")
               .HasMaxLength(13);

        builder.Property(x => x.PublicationDate)
               .IsRequired()
               .HasColumnType("DATETIME");

        builder.Property(x => x.PageCount)
               .IsRequired()
               .HasColumnType("INT");

        builder.Property(x => x.Genre)
               .HasColumnType("VARCHAR(50)")
               .HasMaxLength(50);

        builder.Property(x => x.Language)
               .HasColumnType("VARCHAR(50)")
               .HasMaxLength(50);

        builder.Property(x => x.Price)
               .IsRequired()
               .HasColumnType("DECIMAL(18,2)");

        builder.Property(x => x.Synopsis)
               .HasColumnType("VARCHAR(500)")
               .HasMaxLength(500);
    }
}


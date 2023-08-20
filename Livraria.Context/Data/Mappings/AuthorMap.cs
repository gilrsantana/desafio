using Livraria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Livraria.Context.Data.Mappings;

public class AuthorMap : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable("Authors");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .HasColumnType("UNIQUEIDENTIFIER");

        builder.OwnsOne(x => x.Name, name => {
                name.Property(x => x.FirstName)
                    .IsRequired()
                    .HasColumnType("VARCHAR(80)")
                    .HasMaxLength(80);
                name.Property(x => x.LastName)
                    .IsRequired()
                    .HasColumnType("VARCHAR(80)")
                    .HasMaxLength(80);
        });

        builder.Property(x => x.BirthDate)
               .IsRequired()
               .HasColumnType("DATETIME");

        builder.Property(x => x.DeathDate)
               .HasColumnType("DATETIME");

        builder.Property(x => x.Nationality)
               .HasColumnType("VARCHAR(80)")
               .HasMaxLength(80);

        builder.Property(x => x.Biography)
               .HasColumnType("VARCHAR(500)")
               .HasMaxLength(500);

        builder.HasMany(x => x.BooksAuthored)
               .WithMany(x => x.Authors)
               .UsingEntity<Dictionary<string, object>>(
                    "AuthorsBooks",
                    author => author
                        .HasOne<Book>()
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .HasConstraintName("FK_AuthorsBooks_AuthorId")
                        .OnDelete(DeleteBehavior.Cascade),
                    book => book
                        .HasOne<Author>()
                        .WithMany()
                        .HasForeignKey("BookId")
                        .HasConstraintName("FK_AuthorsBooks_BookId")
                        .OnDelete(DeleteBehavior.Cascade));
    }
}

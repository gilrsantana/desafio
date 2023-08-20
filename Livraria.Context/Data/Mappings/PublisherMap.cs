using Livraria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Livraria.Context.Data.Mappings;

public class PublisherMap : IEntityTypeConfiguration<Publisher>
{
    public void Configure(EntityTypeBuilder<Publisher> builder)
    {
        builder.ToTable("Publishers");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .HasColumnType("UNIQUEIDENTIFIER");

        builder.Property(x => x.Name)
               .IsRequired()
               .HasColumnType("VARCHAR(80)")
               .HasMaxLength(80);

        builder.Property(x => x.LegalName)
               .IsRequired()
               .HasColumnType("VARCHAR(200)")
               .HasMaxLength(200);

        builder.OwnsOne(x => x.Document, document => {
                document.Property(x => x.Number)
                        .IsRequired()
                        .HasColumnType("VARCHAR(25)")
                        .HasMaxLength(25);
                document.Property(x => x.Type)
                        .IsRequired()
                        .HasColumnType("VARCHAR(25)")
                        .HasMaxLength(25)
                        .HasConversion<string>();
        });

        builder.HasMany(x => x.BooksPublished)
               .WithMany(x => x.Publishers)
               .UsingEntity<Dictionary<string, object>>(
                    "PublishersBooks",
                    publisher => publisher
                        .HasOne<Book>()
                        .WithMany()
                        .HasForeignKey("PublisherId")
                        .HasConstraintName("FK_PublishersBooks_PublisherId")
                        .OnDelete(DeleteBehavior.Cascade),
                    book => book
                        .HasOne<Publisher>()
                        .WithMany()
                        .HasForeignKey("BookId")
                        .HasConstraintName("FK_PublishersBooks_BookId")
                        .OnDelete(DeleteBehavior.Cascade));

    }
}



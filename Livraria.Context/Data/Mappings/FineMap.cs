using Livraria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Livraria.Context.Data.Mappings;

public class FineMap : IEntityTypeConfiguration<Fine>
{
    public void Configure(EntityTypeBuilder<Fine> builder)
    {
        builder.ToTable("Fines");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .HasColumnType("UNIQUEIDENTIFIER");

        builder.Property(x => x.Amount)
               .IsRequired()
               .HasColumnType("DECIMAL(18,2)");

        builder.Property(x => x.IsPaid)
               .IsRequired()
               .HasColumnType("BIT");

        builder.Property(x => x.PaymentDate)
               .HasColumnType("DATETIME");
    }
}


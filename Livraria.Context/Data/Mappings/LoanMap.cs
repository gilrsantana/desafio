using Livraria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Livraria.Context.Data.Mappings;

public class LoanMap : IEntityTypeConfiguration<Loan>
{
    public void Configure(EntityTypeBuilder<Loan> builder)
    {
        builder.ToTable("Loans");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .HasColumnType("UNIQUEIDENTIFIER");

        builder.Property(x => x.LoanDate)
               .IsRequired()
               .HasColumnType("DATE");

        builder.Property(x => x.ReturnDate)
               .HasColumnType("DATE");

        builder.Property(x => x.LoanPeriod)
               .IsRequired()
               .HasColumnType("INT");

        builder.HasOne(x => x.User)
               .WithMany(x => x.Loans)
               .HasForeignKey("UserId")
               .HasConstraintName("FK_Loans_UserId")
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Fine)
               .WithOne(x => x.Loan)
               .HasForeignKey<Fine>("LoanId")
               .HasConstraintName("FK_Fines_LoanId")
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Books)
               .WithMany(x => x.Loans)
               .UsingEntity<Dictionary<string, object>>(
                    "LoansBooks",
                    loan => loan
                        .HasOne<Book>()
                        .WithMany()
                        .HasForeignKey("LoanId")
                        .HasConstraintName("FK_LoansBooks_LoanId")
                        .OnDelete(DeleteBehavior.Cascade),
                    book => book
                        .HasOne<Loan>()
                        .WithMany()
                        .HasForeignKey("BookId")
                        .HasConstraintName("FK_LoansBooks_BookId")
                        .OnDelete(DeleteBehavior.Cascade));

    }
}


using Livraria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Livraria.Context.Data.Mappings
{
    internal class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

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

            builder.OwnsOne(x => x.Address, address => {
                    address.Property(x => x.Street)
                           .IsRequired()
                           .HasColumnType("VARCHAR(80)")
                           .HasMaxLength(80);
                    address.Property(x => x.Number)
                           .IsRequired()
                           .HasColumnType("VARCHAR(10)")
                           .HasMaxLength(10);
                    address.Property(x => x.Neighborhood)
                           .IsRequired()
                           .HasColumnType("VARCHAR(80)")
                           .HasMaxLength(80);
                    address.Property(x => x.City)
                           .IsRequired()
                           .HasColumnType("VARCHAR(80)")
                           .HasMaxLength(80);
                    address.Property(x => x.State)
                           .IsRequired()
                           .HasColumnType("VARCHAR(80)")
                           .HasMaxLength(80);
                    address.Property(x => x.Country)
                           .IsRequired()
                           .HasColumnType("VARCHAR(80)")
                           .HasMaxLength(80);
                    address.Property(x => x.ZipCode)
                           .IsRequired()
                           .HasColumnType("VARCHAR(10)")
                           .HasMaxLength(10);
            });

            builder.OwnsOne(x => x.Email, email => {
                    email.Property(x => x.Address)
                         .IsRequired()
                         .HasColumnType("VARCHAR(120)")
                         .HasMaxLength(120);
            });

            builder.HasMany(x => x.Phones)
                   .WithOne(x => x.User)
                   .HasConstraintName("FK_User_Phone")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

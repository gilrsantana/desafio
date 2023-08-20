﻿// <auto-generated />
using System;
using Livraria.Context.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Livraria.Web.API.Migrations
{
    [DbContext(typeof(BookStoreContext))]
    [Migration("20230820084255_Initial Migration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AuthorsBooks", b =>
                {
                    b.Property<Guid>("AuthorId")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<Guid>("BookId")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.HasKey("AuthorId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("AuthorsBooks");
                });

            modelBuilder.Entity("Livraria.Domain.Entities.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<string>("Biography")
                        .HasMaxLength(500)
                        .HasColumnType("VARCHAR(500)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime?>("DeathDate")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Nationality")
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR(80)");

                    b.HasKey("Id");

                    b.ToTable("Authors", (string)null);
                });

            modelBuilder.Entity("Livraria.Domain.Entities.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<string>("Genre")
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("VARCHAR(13)");

                    b.Property<string>("Language")
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)");

                    b.Property<int>("PageCount")
                        .HasColumnType("INT");

                    b.Property<decimal>("Price")
                        .HasColumnType("DECIMAL(18,2)");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Synopsis")
                        .HasMaxLength(500)
                        .HasColumnType("VARCHAR(500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("VARCHAR(150)");

                    b.HasKey("Id");

                    b.ToTable("Books", (string)null);
                });

            modelBuilder.Entity("Livraria.Domain.Entities.Fine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("DECIMAL(18,2)");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("BIT");

                    b.Property<Guid?>("LoanId")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("DATETIME");

                    b.HasKey("Id");

                    b.HasIndex("LoanId")
                        .IsUnique()
                        .HasFilter("[LoanId] IS NOT NULL");

                    b.ToTable("Fines", (string)null);
                });

            modelBuilder.Entity("Livraria.Domain.Entities.Loan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<DateTime>("LoanDate")
                        .HasColumnType("DATE");

                    b.Property<int>("LoanPeriod")
                        .HasColumnType("INT");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("DATE");

                    b.Property<Guid>("UserId")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Loans", (string)null);
                });

            modelBuilder.Entity("Livraria.Domain.Entities.Publisher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<string>("LegalName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR(80)");

                    b.HasKey("Id");

                    b.ToTable("Publishers", (string)null);
                });

            modelBuilder.Entity("Livraria.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Livraria.Domain.ValueObjects.Phone", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Phone");
                });

            modelBuilder.Entity("LoansBooks", b =>
                {
                    b.Property<Guid>("BookId")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<Guid>("LoanId")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.HasKey("BookId", "LoanId");

                    b.HasIndex("LoanId");

                    b.ToTable("LoansBooks");
                });

            modelBuilder.Entity("PublishersBooks", b =>
                {
                    b.Property<Guid>("BookId")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<Guid>("PublisherId")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.HasKey("BookId", "PublisherId");

                    b.HasIndex("PublisherId");

                    b.ToTable("PublishersBooks");
                });

            modelBuilder.Entity("AuthorsBooks", b =>
                {
                    b.HasOne("Livraria.Domain.Entities.Book", null)
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_AuthorsBooks_AuthorId");

                    b.HasOne("Livraria.Domain.Entities.Author", null)
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_AuthorsBooks_BookId");
                });

            modelBuilder.Entity("Livraria.Domain.Entities.Author", b =>
                {
                    b.OwnsOne("Livraria.Domain.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("AuthorId")
                                .HasColumnType("UNIQUEIDENTIFIER");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(80)
                                .HasColumnType("VARCHAR(80)");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(80)
                                .HasColumnType("VARCHAR(80)");

                            b1.HasKey("AuthorId");

                            b1.ToTable("Authors");

                            b1.WithOwner()
                                .HasForeignKey("AuthorId");
                        });

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("Livraria.Domain.Entities.Fine", b =>
                {
                    b.HasOne("Livraria.Domain.Entities.Loan", "Loan")
                        .WithOne("Fine")
                        .HasForeignKey("Livraria.Domain.Entities.Fine", "LoanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_Fines_LoanId");

                    b.Navigation("Loan");
                });

            modelBuilder.Entity("Livraria.Domain.Entities.Loan", b =>
                {
                    b.HasOne("Livraria.Domain.Entities.User", "User")
                        .WithMany("Loans")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Loans_UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Livraria.Domain.Entities.Publisher", b =>
                {
                    b.OwnsOne("Livraria.Domain.ValueObjects.Document", "Document", b1 =>
                        {
                            b1.Property<Guid>("PublisherId")
                                .HasColumnType("UNIQUEIDENTIFIER");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasMaxLength(25)
                                .HasColumnType("VARCHAR(25)");

                            b1.Property<string>("Type")
                                .IsRequired()
                                .HasMaxLength(25)
                                .HasColumnType("VARCHAR(25)");

                            b1.HasKey("PublisherId");

                            b1.ToTable("Publishers");

                            b1.WithOwner()
                                .HasForeignKey("PublisherId");
                        });

                    b.Navigation("Document")
                        .IsRequired();
                });

            modelBuilder.Entity("Livraria.Domain.Entities.User", b =>
                {
                    b.OwnsOne("Livraria.Domain.ValueObjects.Document", "Document", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("UNIQUEIDENTIFIER");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasMaxLength(25)
                                .HasColumnType("VARCHAR(25)");

                            b1.Property<string>("Type")
                                .IsRequired()
                                .HasMaxLength(25)
                                .HasColumnType("VARCHAR(25)");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Livraria.Domain.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("UNIQUEIDENTIFIER");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(80)
                                .HasColumnType("VARCHAR(80)");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(80)
                                .HasColumnType("VARCHAR(80)");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Livraria.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("UNIQUEIDENTIFIER");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(80)
                                .HasColumnType("VARCHAR(80)");

                            b1.Property<string>("Complement")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasMaxLength(80)
                                .HasColumnType("VARCHAR(80)");

                            b1.Property<string>("Neighborhood")
                                .IsRequired()
                                .HasMaxLength(80)
                                .HasColumnType("VARCHAR(80)");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("VARCHAR(10)");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasMaxLength(80)
                                .HasColumnType("VARCHAR(80)");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(80)
                                .HasColumnType("VARCHAR(80)");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("VARCHAR(10)");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Livraria.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("UNIQUEIDENTIFIER");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasMaxLength(120)
                                .HasColumnType("VARCHAR(120)");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Document")
                        .IsRequired();

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("Livraria.Domain.ValueObjects.Phone", b =>
                {
                    b.HasOne("Livraria.Domain.Entities.User", "User")
                        .WithMany("Phones")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_User_Phone");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LoansBooks", b =>
                {
                    b.HasOne("Livraria.Domain.Entities.Loan", null)
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_LoansBooks_BookId");

                    b.HasOne("Livraria.Domain.Entities.Book", null)
                        .WithMany()
                        .HasForeignKey("LoanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_LoansBooks_LoanId");
                });

            modelBuilder.Entity("PublishersBooks", b =>
                {
                    b.HasOne("Livraria.Domain.Entities.Publisher", null)
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_PublishersBooks_BookId");

                    b.HasOne("Livraria.Domain.Entities.Book", null)
                        .WithMany()
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_PublishersBooks_PublisherId");
                });

            modelBuilder.Entity("Livraria.Domain.Entities.Loan", b =>
                {
                    b.Navigation("Fine");
                });

            modelBuilder.Entity("Livraria.Domain.Entities.User", b =>
                {
                    b.Navigation("Loans");

                    b.Navigation("Phones");
                });
#pragma warning restore 612, 618
        }
    }
}

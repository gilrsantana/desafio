using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Livraria.Web.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Name_FirstName = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Name_LastName = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DeathDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Nationality = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: true),
                    Biography = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Title = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false),
                    ISBN = table.Column<string>(type: "VARCHAR(13)", maxLength: 13, nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    PageCount = table.Column<int>(type: "INT", nullable: false),
                    Genre = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true),
                    Language = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true),
                    Price = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    Synopsis = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    LegalName = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    Document_Number = table.Column<string>(type: "VARCHAR(25)", maxLength: 25, nullable: false),
                    Document_Type = table.Column<string>(type: "VARCHAR(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Name_FirstName = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Name_LastName = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Document_Number = table.Column<string>(type: "VARCHAR(25)", maxLength: 25, nullable: false),
                    Document_Type = table.Column<string>(type: "VARCHAR(25)", maxLength: 25, nullable: false),
                    Address_Street = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Address_Number = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    Address_Complement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Neighborhood = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Address_City = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Address_State = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Address_Country = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Address_ZipCode = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    Email_Address = table.Column<string>(type: "VARCHAR(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorsBooks",
                columns: table => new
                {
                    AuthorId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    BookId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorsBooks", x => new { x.AuthorId, x.BookId });
                    table.ForeignKey(
                        name: "FK_AuthorsBooks_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorsBooks_BookId",
                        column: x => x.BookId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublishersBooks",
                columns: table => new
                {
                    BookId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    PublisherId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublishersBooks", x => new { x.BookId, x.PublisherId });
                    table.ForeignKey(
                        name: "FK_PublishersBooks_BookId",
                        column: x => x.BookId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublishersBooks_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    UserId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    LoanDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "DATE", nullable: true),
                    LoanPeriod = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loans_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phone",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Phone",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Amount = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsPaid = table.Column<bool>(type: "BIT", nullable: false),
                    LoanId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fines_LoanId",
                        column: x => x.LoanId,
                        principalTable: "Loans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoansBooks",
                columns: table => new
                {
                    BookId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    LoanId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoansBooks", x => new { x.BookId, x.LoanId });
                    table.ForeignKey(
                        name: "FK_LoansBooks_BookId",
                        column: x => x.BookId,
                        principalTable: "Loans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoansBooks_LoanId",
                        column: x => x.LoanId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorsBooks_BookId",
                table: "AuthorsBooks",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Fines_LoanId",
                table: "Fines",
                column: "LoanId",
                unique: true,
                filter: "[LoanId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_UserId",
                table: "Loans",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LoansBooks_LoanId",
                table: "LoansBooks",
                column: "LoanId");

            migrationBuilder.CreateIndex(
                name: "IX_Phone_UserId",
                table: "Phone",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PublishersBooks_PublisherId",
                table: "PublishersBooks",
                column: "PublisherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorsBooks");

            migrationBuilder.DropTable(
                name: "Fines");

            migrationBuilder.DropTable(
                name: "LoansBooks");

            migrationBuilder.DropTable(
                name: "Phone");

            migrationBuilder.DropTable(
                name: "PublishersBooks");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

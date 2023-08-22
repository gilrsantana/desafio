using Livraria.Context.Data.Mappings;
using Livraria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace Livraria.Context.Data;

public class BookStoreContext : DbContext
{
    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Author> Authors { get; set; } = null!;
    public DbSet<Publisher> Publishers { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Loan> Loans { get; set; } = null!;
    public DbSet<Fine> Fines { get; set; } = null!;

    public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BookMap());
        modelBuilder.ApplyConfiguration(new AuthorMap());
        modelBuilder.ApplyConfiguration(new PublisherMap());
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new LoanMap());
        modelBuilder.ApplyConfiguration(new FineMap());
    }
}

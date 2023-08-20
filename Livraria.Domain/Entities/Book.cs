using Livraria.Shared.Entities;

namespace Livraria.Domain.Entities;

public class Book : BaseEntity
{
    public string Title { get; private set; } = null!;
    public string ISBN { get; private set; } = null!;
    public DateTime PublicationDate { get; private set; }
    public int PageCount { get; private set; }
    public string? Genre { get; private set; }
    public string? Language { get; private set; }
    public decimal Price { get; private set; }
    public string? Synopsis { get; private set; }
    public ICollection<Author>? Authors { get; private set; }
    public ICollection<Publisher>? Publishers { get; private set; }
    public ICollection<Loan>? Loans { get; private set; }
}

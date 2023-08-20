using Livraria.Domain.ValueObjects;
using Livraria.Shared.Entities;

namespace Livraria.Domain.Entities;

public class Author : BaseEntity
{
    public Name Name { get; private set; } = null!;
    public DateTime BirthDate { get; private set; }
    public DateTime? DeathDate { get; private set; }
    public string? Nationality { get; private set; }
    public string? Biography { get; private set; }
    public ICollection<Book>? BooksAuthored { get; private set; }
}

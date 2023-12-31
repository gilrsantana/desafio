using Livraria.Domain.ValueObjects;
using Livraria.Shared.Entities;

namespace Livraria.Domain.Entities;

public class Author : BaseEntity
{
    public Name Name { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public DateTime? DeathDate { get; set; }
    public string? Nationality { get; set; }
    public string? Biography { get; set; }
    public ICollection<Book>? BooksAuthored { get; set; }
}

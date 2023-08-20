using Livraria.Domain.ValueObjects;
using Livraria.Shared.Entities;

namespace Livraria.Domain.Entities;

public class Publisher : BaseEntity
{
    public string Name { get; private set; } = null!;
    public string LegalName { get; private set; } = null!;
    public Document Document { get; private set; } = null!;
    public ICollection<Book>? BooksPublished { get; private set; }
}

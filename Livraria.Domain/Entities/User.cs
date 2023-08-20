using Livraria.Domain.ValueObjects;
using Livraria.Shared.Entities;

namespace Livraria.Domain.Entities;

public class User : BaseEntity
{
    public Name Name { get; private set; } = null!;
    public Document Document { get; private set; } = null!;
    public Address Address { get; private set; } = null!;
    public Email Email { get; private set; } = null!;
    public ICollection<Phone>? Phones { get; private set; }
    public ICollection<Loan>? Loans { get; private set; }
}

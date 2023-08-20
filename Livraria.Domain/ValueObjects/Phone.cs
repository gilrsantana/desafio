using Livraria.Domain.Entities;
using Livraria.Domain.Enums;
using Livraria.Shared.Entities;

namespace Livraria.Domain.ValueObjects;

public class Phone : BaseEntity
{
    public string Number { get; private set; } = null!;
    public EPhoneType Type { get; private set; }
    public User? User{ get; private set; }
}

using Livraria.Domain.Enums;
using Livraria.Shared.Entities;

namespace Livraria.Domain.ValueObjects;

public class Document
{
    public string Number { get; private set; } = null!;
    public EDocumentType Type { get; private set; }
}

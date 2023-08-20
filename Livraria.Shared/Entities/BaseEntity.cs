namespace Livraria.Shared.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; private set; }

    public BaseEntity()
    {
        Id = Guid.NewGuid();
    }
}

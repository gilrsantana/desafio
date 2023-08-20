namespace Livraria.Domain.ValueObjects;

public class Name
{
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}

namespace Livraria.Domain.ValueObjects;

public class Name
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}

namespace Livraria.Domain.ValueObjects;

public class Email
{
    public string Address { get; private set; }

    public Email(string address)
    {
        Address = address;
    }

    public bool Validate()
    {
        return Address.Contains("@") && Address.Contains(".") && Address.Length >= 5;
    }
}

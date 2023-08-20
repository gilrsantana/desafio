namespace Livraria.Domain.ValueObjects;

public class Address
{

    public string Street { get; private set; } = null!;
    public string Number { get; private set; } = null!;
    public string Complement { get; private set; } = null!;
    public string Neighborhood { get; private set; } = null!;
    public string City { get; private set; } = null!;
    public string State { get; private set; } = null!;
    public string Country { get; private set; } = null!;
    public string ZipCode { get; private set; } = null!;

    public Address(string street, 
        string number, 
        string complement, 
        string neighborhood, 
        string city, 
        string state, 
        string country, 
        string zipCode)
    {
        Street = street;
        Number = number;
        Complement = complement;
        Neighborhood = neighborhood;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;
    }

    public override string ToString()
    {
        return $"{Street}, {Number} - {Complement} - {Neighborhood} - {City}/{State} - {Country} - {ZipCode}";
    }
        
}

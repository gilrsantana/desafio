using Livraria.Domain.ValueObjects;
using Livraria.Shared.Messages;

namespace Livraria.Test.Mock;

public static class MockAuthor
{
    public static ICollection<Author> ListOfAuthors =>
        new List<Author>
        {
            new Author
            {
                Name = new Name { FirstName = "Teste1", LastName = "Author" },
                BirthDate = DateTime.Now,
                DeathDate = null,
                Biography = "",
                BooksAuthored = null
            },
            new Author
            {
                Name = new Name { FirstName = "Teste2", LastName = "Author" },
                BirthDate = DateTime.Now,
                DeathDate = null,
                Biography = "",
                BooksAuthored = null
            },
            new Author
            {
                Name = new Name { FirstName = "Teste3", LastName = "Author" },
                BirthDate = DateTime.Now,
                DeathDate = null,
                Biography = "",
                BooksAuthored = null
            }
        };

    public static Author AuthorEntity = new Author
    {
        Name = new Name { FirstName = "Teste1", LastName = "Author" },
        BirthDate = DateTime.Now,
        DeathDate = null,
        Biography = "",
        BooksAuthored = null
    };

    public static IEnumerable<object[]> WithInvalidGuid = new[]
    {
        new object[]
        {
            Guid.Empty
        }
    };
}
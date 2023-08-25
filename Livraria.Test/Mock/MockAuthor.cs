using Livraria.Domain.Entities;
using Livraria.Domain.ValueObjects;

namespace Livraria.Test.Mock;

public static class MockAuthor
{
    public static Author GetAuthor()
    {
        return new Domain.Entities.Author 
        { Name = new Name { FirstName = "Teste1", LastName = "Author" },
            BirthDate = DateTime.Now,
            DeathDate = null,
            Biography = "",
            BooksAuthored = null
        };
    }
    
    public static List<Author> GetAuthorsList()
    {
        return new List<Author>
        {
            new Author 
            { Name = new Name { FirstName = "Teste1", LastName = "Author" },
                BirthDate = DateTime.Now,
                DeathDate = null,
                Biography = "",
                BooksAuthored = null
            },
            new Author 
            { Name = new Name { FirstName = "Teste2", LastName = "Author" },
                BirthDate = DateTime.Now,
                DeathDate = null,
                Biography = "",
                BooksAuthored = null
            },
            new Author 
            { Name = new Name { FirstName = "Teste3", LastName = "Author" },
                BirthDate = DateTime.Now,
                DeathDate = null,
                Biography = "",
                BooksAuthored = null
            }
        };
    }
}
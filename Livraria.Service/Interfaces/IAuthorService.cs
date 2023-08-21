using Livraria.Domain.Entities;

namespace Livraria.Service.Interfaces;

public interface IAuthorService
{
    Task<IList<Author>> GetAllAuthorsAsync(int skip = 0, int take = 25);
    Author? GetAuthorByIdAsync(Guid id);
    bool InsertAuthorAsync(Author author);
    bool UpdateAuthorAsync(Author author);
}


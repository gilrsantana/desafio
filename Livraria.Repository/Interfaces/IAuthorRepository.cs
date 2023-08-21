using Livraria.Domain.Entities;

namespace Livraria.Repository.Interfaces;

public interface IAuthorRepository
{
    Task<IList<Author>> GetAllAuthorsAsync(int skip = 0, int take = 25);
    Author? GetAuthorByIdAsync(Guid id);
    bool InsertAuthorAsync(Author author);
    bool UpdateAuthorAsync(Author author);
}

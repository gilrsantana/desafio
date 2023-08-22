using Livraria.Domain.Entities;

namespace Livraria.Service.Interfaces;

public interface IAuthorService
{
    Task<IList<Author>> GetAllAuthorsAsync(int skip = 0, int take = 25);
    Task<Author?> GetAuthorByIdAsync(Guid id);
    Task<bool?> InsertAuthorAsync(Author author);
    Task<bool?> UpdateAuthorAsync(Guid id, Author author);
}


using Livraria.Domain.Entities;

namespace Livraria.Repository.Interfaces;

public interface IAuthorRepository
{
    Task<ICollection<Author>> GetAllAuthorsAsync(int skip = 0, int take = 25);
    Task<Author?> GetAuthorByIdAsync(Guid id);
    Task<bool> InsertAuthorAsync(Author author);
    Task<bool> UpdateAuthorAsync(Author author);
}

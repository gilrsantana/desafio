using Livraria.Domain.Entities;
using Livraria.Shared.Presenters;

namespace Livraria.Service.Interfaces;

public interface IAuthorService
{
    Task<Presenter<ICollection<Author>>> GetAllAuthorsAsync(int skip = 0, int take = 25);
    Task<Presenter<Author?>> GetAuthorByIdAsync(Guid id);
    Task<Presenter<bool>> InsertAuthorAsync(Author author);
    Task<Presenter<bool>> UpdateAuthorAsync(Guid id, Author author);
}


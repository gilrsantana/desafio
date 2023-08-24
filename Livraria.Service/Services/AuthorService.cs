using Livraria.Domain.Entities;
using Livraria.Repository.Interfaces;
using Livraria.Service.Interfaces;

namespace Livraria.Service.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }
    public async Task<IList<Author>> GetAllAuthorsAsync(int skip = 0, int take = 25)
    {
        return (await _authorRepository.GetAllAuthorsAsync(skip, take))
            .OrderBy(a => a.Name.FirstName)
            .ThenBy(x => x.Name.LastName)
            .ToList();
    }

    public async Task<Author?> GetAuthorByIdAsync(Guid id)
    {
        return await _authorRepository.GetAuthorByIdAsync(id);
    }

    public Task<bool?> InsertAuthorAsync(Author author)
    {
        return _authorRepository.InsertAuthorAsync(author);
    }

    public async Task<bool?> UpdateAuthorAsync(Guid id, Author author)
    {
        author.Id = id;
        return await _authorRepository.UpdateAuthorAsync(author);
    }
}


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
        return await _authorRepository.GetAllAuthorsAsync(skip, take);
    }

    public Author? GetAuthorByIdAsync(Guid id)
    {
        return _authorRepository.GetAuthorByIdAsync(id);
    }

    public bool InsertAuthorAsync(Author author)
    {
        return _authorRepository.InsertAuthorAsync(author);
    }

    public bool UpdateAuthorAsync(Author author)
    {
        return _authorRepository.UpdateAuthorAsync(author);
    }
}


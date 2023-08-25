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
    public async Task<IList<Author>> GetAllAuthorsAsync(int skip = 0, int take = 25) => 
        await _authorRepository.GetAllAuthorsAsync(skip, take);
    
    public async Task<Author?> GetAuthorByIdAsync(Guid id) =>
        await _authorRepository.GetAuthorByIdAsync(id);
    
    public async Task<bool?> InsertAuthorAsync(Author author) =>
        await _authorRepository.InsertAuthorAsync(author);
    

    public async Task<bool?> UpdateAuthorAsync(Guid id, Author author)
    {
        author.Id = id;
        return await _authorRepository.UpdateAuthorAsync(author);
    }
}


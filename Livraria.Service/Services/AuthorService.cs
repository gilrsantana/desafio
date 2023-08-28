using Livraria.Domain.Entities;
using Livraria.Repository.Interfaces;
using Livraria.Service.Interfaces;
using Livraria.Shared.Messages;
using Livraria.Shared.Presenters;

namespace Livraria.Service.Services;

public class AuthorService : IAuthorService 
{
    private readonly IAuthorRepository _authorRepository;
    private readonly List<string> _errors = new();
    public AuthorService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<Presenter<ICollection<Author>>> GetAllAuthorsAsync(int skip = 0, int take = 25)
    {
        if (skip < 0 || take < 1)
        {
            _errors.Add(Error.Common.INVALID_SKIP_TAKE);
            return new Presenter<ICollection<Author>>(new List<Author>(), _errors);
        }
        
        var collection = await _authorRepository.GetAllAuthorsAsync(skip, take);
        if (!collection.Any())
            _errors.Add(Error.Author.NOT_FOUND);

        return _errors.Any()
            ? new Presenter<ICollection<Author>>(new List<Author>(), _errors)
            : new Presenter<ICollection<Author>>(collection);
    }
    
    public async Task<Presenter<Author?>> GetAuthorByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            _errors.Add(Error.Common.INVALID_ID);
            return new Presenter<Author?>(null, _errors);
        }
        
        var collection = await _authorRepository.GetAuthorByIdAsync(id);
        
        if (collection is null)
            _errors.Add(Error.Author.NOT_FOUND);
        
        return _errors.Any()
            ? new Presenter<Author?>(null, _errors)
            : new Presenter<Author?>(collection);
    }

    public async Task<Presenter<bool>> InsertAuthorAsync(Author author)
    {
        var result = await _authorRepository.InsertAuthorAsync(author);
        if (result is false)
            _errors.Add(Error.Author.NOT_INSERTED);

        return _errors.Any()
            ? new Presenter<bool>(false, _errors)
            : new Presenter<bool>(true);
    }

    public async Task<Presenter<bool>> UpdateAuthorAsync(Guid id, Author author)
    {
        if (id == Guid.Empty)
        {
            _errors.Add(Error.Common.INVALID_ID);
            return new Presenter<bool>(false, _errors);
        }
        
        author.Id = id;
        var result = await _authorRepository.UpdateAuthorAsync(author);
        
        if (result is false)
            _errors.Add(Error.Author.NOT_UPDATED);
        
        return _errors.Any()
            ? new Presenter<bool>(false, _errors)
            : new Presenter<bool>(true);
    }
}


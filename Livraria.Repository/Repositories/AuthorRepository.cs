using Livraria.Context.Data;
using Livraria.Domain.Entities;
using Livraria.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Repository.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly BookStoreContext _context;

    public AuthorRepository(BookStoreContext context)
    {
        _context = context;
    }

    public async Task<IList<Author>> GetAllAuthorsAsync(int skip = 0, int take = 25)
    {
        return await _context.Authors
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }

    public Author? GetAuthorByIdAsync(Guid id)
    {
        return _context.Authors
            .FirstOrDefault(x => x.Id == id);
    }

    public bool InsertAuthorAsync(Author author)
    {
        return _context.Authors
            .Add(author)
            .State == EntityState.Added;
    }

    public bool UpdateAuthorAsync(Author author)
    {
        return _context.Authors
            .Update(author)
            .State == EntityState.Modified;
    }
}


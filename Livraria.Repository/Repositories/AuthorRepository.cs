﻿using Livraria.Context.Data;
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

    public async Task<ICollection<Author>> GetAllAuthorsAsync(int skip = 0, int take = 25)
    {
        return await _context.Authors
            .OrderBy(a => a.Name.FirstName)
            .ThenBy(a => a.Name.LastName)
            .Skip(skip)
            .Take(take)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Author?> GetAuthorByIdAsync(Guid id) => 
        await _context.Authors.AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);
    
    
    public async Task<bool> InsertAuthorAsync(Author author)
    {
        _context.Authors.Add(author);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAuthorAsync(Author author)
    {
        _context.Authors.Update(author);
        return await _context.SaveChangesAsync() > 0;
    }
}


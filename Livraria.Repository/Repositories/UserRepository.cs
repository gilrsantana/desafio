using System.Collections;
using Livraria.Context.Data;
using Livraria.Domain.Entities;
using Livraria.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Repository.Repositories;

public class UserRepository : IUserRepository
{
    private readonly BookStoreContext _context;
    
    public UserRepository(BookStoreContext context)
    {
        _context = context;
    }
    
    public async Task<ICollection> GetAllUsersAsync(int skip = 0, int take = 25)
    {
        return await _context.Users
            .OrderBy(a => a.Name.FirstName)
            .ThenBy(a => a.Name.LastName)
            .Skip(skip)
            .Take(take)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<User?> GetUserByIdAsync(Guid id) =>
        await _context.Users.AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == id);
    

    public async Task<bool> InsertUserAsync(User user)
    {
        _context.Users.Add(user);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateUserAsync(User user)
    {
        _context.Users.Update(user);
        return await _context.SaveChangesAsync() > 0;
    }
}
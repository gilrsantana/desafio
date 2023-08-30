using System.Collections;
using Livraria.Domain.Entities;

namespace Livraria.Repository.Interfaces;

public interface IUserRepository
{
    Task<ICollection> GetAllUsersAsync(int skip = 0, int take = 25);
    Task<User?> GetUserByIdAsync(Guid id);
    Task<bool> InsertUserAsync(User user);
    Task<bool> UpdateUserAsync(User user);
}
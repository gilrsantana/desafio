using Livraria.Domain.Entities;
using Livraria.Shared.Presenters;

namespace Livraria.Service.Interfaces;

public interface IUserService
{
    Task<Presenter<ICollection<User>>> GetAllUsersAsync(int skip = 0, int take = 25);
    Task<Presenter<User?>> GetUserByIdAsync(Guid id);
    Task<Presenter<bool>> InsertUserAsync(User user);
    Task<Presenter<bool>> UpdateUserAsync(Guid id, User user);
}
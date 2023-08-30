using Livraria.Domain.Entities;
using Livraria.Service.Interfaces;
using Livraria.Shared.Presenters;

namespace Livraria.Service.Services;

public class UserService : IUserService
{
    public async Task<Presenter<ICollection<User>>> GetAllUsersAsync(int skip = 0, int take = 25)
    {
        throw new NotImplementedException();
    }

    public async Task<Presenter<User?>> GetUserByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Presenter<bool>> InsertUserAsync(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<Presenter<bool>> UpdateUserAsync(Guid id, User user)
    {
        throw new NotImplementedException();
    }
}
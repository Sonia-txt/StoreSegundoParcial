using Store.Core.Entities;
using Store.Api.Repositories.Interface;

namespace Store.Api.Repositories;

public class UserRepository : IUserRepository
{
    private readonly List<User> _users = new();
    private int _nextId = 1;

    public async Task<List<User>> GetAllAsync() => await Task.FromResult(_users.ToList());

    public async Task<User> GetById(int id) => 
        await Task.FromResult(_users.FirstOrDefault(x => x.Id == id));

    public async Task<User> SaveAsync(User user)
    {
        user.Id = _nextId++;
        _users.Add(user);
        return await Task.FromResult(user);
    }

    public async Task<bool> UpdateAsync(User user)
    {
        var index = _users.FindIndex(x => x.Id == user.Id);
        if (index == -1) return await Task.FromResult(false);
        _users[index] = user;
        return await Task.FromResult(true);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var user = _users.FirstOrDefault(x => x.Id == id);
        if (user == null) return await Task.FromResult(false);
        return await Task.FromResult(_users.Remove(user));
    }
}
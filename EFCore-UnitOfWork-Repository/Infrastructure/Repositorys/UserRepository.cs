using EFCoreRelationshipsTutorial.Data;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationshipsTutorial.Infrastructure.Repositorys;

public class UserRepository : IRepository<User>
{
    public async Task Create(User item)
    {
        
        _dataContext.Users.Add(item);
    }

    public async Task Delete(int id)
    {
        User user = await _dataContext.Users.FindAsync(id);
        if (user != null)
            _dataContext.Users.Remove(user);
    }

    public async Task<User> Get(int id)
    {
        User user = await _dataContext.Users.FindAsync(id);
        return user;
    }

    public async  Task<List<User>>GetAll()
    {
        return await _dataContext.Users.Include(e=>e.Characters).ToListAsync();
    }

    public async Task Update(User item)
    {
        _dataContext.Entry(item).State = EntityState.Modified;
    }
    private readonly DataContext _dataContext;

    public UserRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
}

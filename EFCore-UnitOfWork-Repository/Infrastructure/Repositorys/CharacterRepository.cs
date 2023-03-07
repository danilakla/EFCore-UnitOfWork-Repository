using EFCoreRelationshipsTutorial.Data;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationshipsTutorial.Infrastructure.Repositorys;

public class CharacterRepository : IRepository<Character>
{
    private readonly DataContext _dataContext;

    public CharacterRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task Create(Character item)
    {
        _dataContext.Characters.Add(item);
    }

    public async Task Delete(int id)
    {
        Character character = await _dataContext.Characters.FindAsync(id);
        if (character != null)
            _dataContext.Characters.Remove(character);
    }

    public async Task<Character> Get(int id)
    {
        var user = await _dataContext.Characters.FindAsync(id);
        return user;
    }

    public async Task<List<Character>> GetAll()
    {
        return await _dataContext.Characters.Include(e => e.User).Include(e=>e.Weapon).ToListAsync();
    }

    public Task Update(Character item)
    {
        throw new NotImplementedException();
    }

 
}

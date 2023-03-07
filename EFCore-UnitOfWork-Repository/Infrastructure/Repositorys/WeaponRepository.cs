using EFCoreRelationshipsTutorial.Data;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationshipsTutorial.Infrastructure.Repositorys;

public class WeaponRepository : IRepository<Weapon>
{
    private readonly DataContext _dataContext;

    public WeaponRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task Create(Weapon item)
    {
        _dataContext.Weapons.Add(item);
    }

    public  async Task Delete(int id)
    {
        Weapon weapon = await _dataContext.Weapons.FindAsync(id);
        if (weapon != null)
            _dataContext.Weapons.Remove(weapon);
    }

    public Task<Weapon> Get(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Weapon>> GetAll()
    {
        return await _dataContext.Weapons.Include(e => e.Character).ToListAsync();

    }


    public async Task<List<Weapon>> GetByNameDamage(string name , int damage)
    {
        return await _dataContext.Weapons.Where(e=>e.Damage==damage).Where(e=>e.Name==name).ToListAsync();

    }
    public async Task<List<Weapon>> GetSortByDamageDesc()
    {
        return await _dataContext.Weapons.OrderByDescending(e=>e.Damage).ToListAsync();

    }

    public async Task<List<Weapon>> GetSortByDamage()
    {
        return await _dataContext.Weapons.OrderBy(e => e.Damage).ToListAsync();

    }


    public Task Update(Weapon item)
    {
        throw new NotImplementedException();
    }

   
}

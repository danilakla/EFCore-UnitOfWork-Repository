using EFCoreRelationshipsTutorial.Data;

namespace EFCoreRelationshipsTutorial.Infrastructure.Repositorys;

public class SkillRepository : IRepository<Skill>
{
    private readonly DataContext _dataContext;

   
    public SkillRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public Task Create(Skill item)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Skill> Get(int id)
    {
        throw new NotImplementedException();
    }

  
    public Task Update(Skill item)
    {
        throw new NotImplementedException();
    }

    Task<List<Skill>> IRepository<Skill>.GetAll()
    {
        throw new NotImplementedException();
    }
}

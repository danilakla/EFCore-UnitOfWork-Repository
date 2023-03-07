using EFCoreRelationshipsTutorial.Infrastructure.Repositorys;

namespace EFCoreRelationshipsTutorial.Infrastructure.UnitOfWorks;

public interface IUnitOfWork
{
    
    public CharacterRepository CharacterRepository { get; }
    public SkillRepository SkillRepository { get; }

    public UserRepository UserRepository { get; }
    public WeaponRepository WeaponRepository{ get; }

    public Task BeginTransaction();
    public Task Commit();
    public Task RollBackTransaction();
    public Task CreateSavepoint(string nameSavePoint);
    
            public Task RollbackToSavepoint(string nameSavePoint);



    public Task Save();

}

using EFCoreRelationshipsTutorial.Data;
using EFCoreRelationshipsTutorial.Infrastructure.Repositorys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Transactions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EFCoreRelationshipsTutorial.Infrastructure.UnitOfWorks;


public class UnitOfWork : IUnitOfWork
{

    public CharacterRepository _characterRepository;
    public SkillRepository _skillRepository;

    public UserRepository _userRepository;
    public WeaponRepository _weaponRepository;
    private IDbContextTransaction _transaction;
    public UnitOfWork(DataContext dataContext)
    {
        _dataContext = dataContext;
    }


    public async Task Save()
    {
     await    _dataContext.SaveChangesAsync();
    }

    public async Task BeginTransaction()
    {
        _transaction=await _dataContext.Database.BeginTransactionAsync(System.Data.IsolationLevel.Serializable);
    }

    public async Task Commit()
    {
        await _transaction.CommitAsync();
    }

    public async Task CreateSavepoint(string nameSavePoint)
    {
      await  _transaction.CreateSavepointAsync(nameSavePoint);
    }

    public async Task RollbackToSavepoint(string nameSavePoint)
    {
       await  _transaction.RollbackToSavepointAsync(nameSavePoint);

    }

    public async Task RollBackTransaction()
    {
            await _transaction.RollbackAsync();
    }

    private readonly DataContext _dataContext;

    public CharacterRepository CharacterRepository { get {

            if (_characterRepository == null)
                _characterRepository = new CharacterRepository(_dataContext);
            return _characterRepository;
        } }

    public SkillRepository SkillRepository
    {
        get
        {

            if (_skillRepository == null)
                _skillRepository = new SkillRepository(_dataContext);
            return _skillRepository;
        }
    }

    public UserRepository UserRepository
    {
        get
        {

            if (_userRepository == null)
                _userRepository = new UserRepository(_dataContext);
            return _userRepository;
        }
    }
    public WeaponRepository WeaponRepository
    {
        get
        {

            if (_weaponRepository == null)
                _weaponRepository = new WeaponRepository(_dataContext);
            return _weaponRepository;
        }
    }


}

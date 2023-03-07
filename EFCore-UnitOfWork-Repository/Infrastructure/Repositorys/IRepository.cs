﻿using System.Threading.Tasks;

namespace EFCoreRelationshipsTutorial.Infrastructure.Repositorys;

public interface IRepository<T> where T : class
{
    Task<List<T>> GetAll();
    Task<T> Get(int id);
    Task Create(T item);
    Task Update(T item);
    Task Delete(int id);
}

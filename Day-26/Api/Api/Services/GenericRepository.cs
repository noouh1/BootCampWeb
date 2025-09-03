using Api.Data;
using Api.Data;
using Api.Dto;
using Api.Interfaces;
using Api.Models;
namespace Api.Services;

public class GenericRepository<TEntity>(ApplicationDbContext applicationDbContext): IGenericRepository<TEntity> where TEntity : class
{
    public void Add(TEntity entity)
    {
        applicationDbContext.Set<TEntity>().Add(entity);
    }

    public void Delete(TEntity entity)
    {
        applicationDbContext.Set<TEntity>().Remove(entity);
    }

    public void Update(TEntity entity)
    {
        applicationDbContext.Set<TEntity>().Update(entity);
    }

    public TEntity? GetById(int id)
    {
        return applicationDbContext.Set<TEntity>().Find(id);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return applicationDbContext.Set<TEntity>().ToList();
    }
}
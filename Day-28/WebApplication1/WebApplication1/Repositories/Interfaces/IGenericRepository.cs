using WebApplication1.Specifcations.Base;

namespace WebApplication1.Repositories.Interfaces;

public interface IGenericRepository <TEntity> where TEntity : class
{
    public Task Create(TEntity entity);

    public Task<List<TEntity>> GetAll();

    public Task<TEntity> GetById(int id);

    public Task Update(TEntity entity);

    public void Delete(TEntity entity);
    
    public IQueryable<TEntity> GetTableAsNoTrackingWithSpec(ISpecification<TEntity> specification);
}
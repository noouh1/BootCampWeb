using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Specifcations.Base;

namespace WebApplication1.Repositories.Implementations;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly ApplicationDbContext _context;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public virtual async Task Create(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public virtual void Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }

    public virtual async Task<List<TEntity>> GetAll()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public virtual async Task<TEntity> GetById(int id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public virtual async Task Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public IQueryable<TEntity> GetTableAsNoTrackingWithSpec(ISpecification<TEntity> specification)
    {
        var start = _context.Set<TEntity>().AsNoTracking().AsQueryable();
        var dataqurable = SpecificationEvaluator<TEntity>.GetQueryWithSpec(start, specification);
        return dataqurable;
    }

}
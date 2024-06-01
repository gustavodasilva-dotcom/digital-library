using System.Linq.Expressions;
using DigitalLibrary.Modules.Lendings.Domain.Abstractions;
using DigitalLibrary.Modules.Lendings.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalLibrary.Modules.Lendings.Persistence.Repositories;

internal class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Entity
{
    private readonly LendingDbContext _dbContext;

    public RepositoryBase(LendingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual List<TEntity> Get(int page = 0, int size = 10)
    {
        return _dbContext.Set<TEntity>().AsNoTracking()
            .Skip((page - 1) * size)
            .Take(size)
            .ToList();
    }

    public virtual TEntity? Get(Expression<Func<TEntity, bool>> expression)
    {
        return _dbContext.Set<TEntity>().SingleOrDefault(expression);
    }

    public void Add(TEntity entity)
    {
        _dbContext.Set<TEntity>().Add(entity);
    }

    public void Update(TEntity entity)
    {
        _dbContext.Set<TEntity>().Update(entity);
    }

    public void Remove(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
    }
}

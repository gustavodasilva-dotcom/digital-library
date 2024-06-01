using System.Linq.Expressions;
using DigitalLibrary.Modules.Lendings.Domain.Entities;

namespace DigitalLibrary.Modules.Lendings.Domain.Abstractions;

public interface IRepositoryBase<TEntity> where TEntity : Entity
{
    List<TEntity> Get(int page = 0, int size = 10);
    
    TEntity? Get(Expression<Func<TEntity, bool>> expression);
    
    void Add(TEntity entity);

    void Update(TEntity entity);

    void Remove(TEntity entity);
}

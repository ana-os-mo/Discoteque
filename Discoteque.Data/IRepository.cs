namespace Discoteque.Data;

using System.Linq.Expressions;
using Discoteque.Data.Models;

public interface IRepository<TId, TEntity>
where TId : struct
where TEntity : BaseEntity<TId>
{
  Task AddAsync(TEntity entity);
  Task<IEnumerable<TEntity>> GetAllAsync(
    Expression<Func<TEntity, bool>>? filter = null,
    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
    string includeProperties = ""
  );
  Task<TEntity> FindAsync(TId id);
  Task Update(TEntity entity);
  Task Delete(TEntity entity);
  Task Delete(TId id);
}

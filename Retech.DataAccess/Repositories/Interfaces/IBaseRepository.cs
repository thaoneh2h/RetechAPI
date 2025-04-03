using System.Linq.Expressions;
using Retech.Core.Common;

namespace Footprint.DataAccess.Repositories;

public interface IBaseRepository<TEntity> where TEntity : ISoftDelete<Guid>
{
    Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate);
    Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);

    Task<List<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>>? predicate = null, string? include = null,
        int? pageIndex = null, int? pageSize = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, bool? forUpdate = null);

    Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> predicate, string? include = null,
        bool? forUpdate = null!);

    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> DeleteAsync(TEntity entity);
    Task SoftDeleteAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task UpdateRange(IEnumerable<TEntity> t);
    Task<IQueryable<TEntity>> FindAllAsyncAsQueryable(Expression<Func<TEntity, bool>> expression);
    Task<IQueryable<TEntity>> GetAllAsyncAsQueryable();
    Task AddRange(IEnumerable<TEntity> t);
}

using System.Linq.Expressions;
using Retech.Core.Common;
using Retech.Shared.Models.Paginations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Footprint.DataAccess.Repositories;
using Retech.DataAccess.DataContext;

namespace Retech.DataAccess.Repositories.Implementations;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, ISoftDelete<Guid>
{
    protected readonly AppDbContext Context;
    protected readonly DbSet<TEntity> DbSet;

    public BaseRepository(AppDbContext context)
    {
        Context = context;
        DbSet = context.Set<TEntity>();
    }

    public async Task<List<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>>? predicate = null,
        string? include = null, int? pageIndex = null, int? pageSize = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, bool? forUpdate = null)
    {
        IQueryable<TEntity> query = DbSet;
        if (!string.IsNullOrEmpty(include))
            foreach (var item in include.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                if (forUpdate.HasValue && forUpdate.Value)
                    query = query.Include(item.Trim());
                else
                    query = query.Include(item.Trim()).AsNoTracking();
        if (predicate != null) query = query.Where(predicate);
        if (orderBy != null) query = orderBy(query);
        if (pageIndex.HasValue && pageSize.HasValue)
        {
            var sizeR = 10;
            var paginationModel = new PaginationModel();
            var serviceProvider = new ServiceCollection().BuildServiceProvider();
            var configuration = serviceProvider.GetService<IConfiguration>();
            if (configuration != null)
            {
                configuration.GetSection(nameof(PaginationModel)).Bind(paginationModel);
                if (paginationModel.PageSize > 0) sizeR = paginationModel.PageSize;
            }

            var index = pageIndex.Value > 0 ? pageIndex.Value - 1 : 0;
            var size = pageSize.Value > 0 ? pageSize.Value : sizeR;
            query = query.Skip(index * size).Take(size);
        }
        return await query.ToListAsync();
    }

    public async Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> predicate, string? include = null,
        bool? forUpdate = null!)
    {
        IQueryable<TEntity> query = DbSet;
        if (!string.IsNullOrEmpty(include))
            foreach (var item in include.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                if (forUpdate.HasValue && forUpdate.Value)
                    query = query.Include(item);
                else
                    query = query.Include(item).AsNoTracking();
        return (await query.FirstOrDefaultAsync(predicate))!;
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        var addedEntity = (await DbSet.AddAsync(entity)).Entity;
        return addedEntity;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        var removedEntity = DbSet.Remove(entity).Entity;
        await Task.CompletedTask;
        return removedEntity;
    }

    public async Task SoftDeleteAsync(TEntity entity)
    {
        entity.IsDeleted = true;
        entity.DeletedAt = DateTime.Now;
        await UpdateAsync(entity);
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await DbSet.Where(predicate).ToListAsync();
    }

    public async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var entity = await DbSet.Where(predicate).FirstOrDefaultAsync();

        //if (entity == null) throw new ResourceNotFoundException(typeof(TEntity));

        return (await DbSet.Where(predicate).FirstOrDefaultAsync())!;
    }

    // through mapper -> get entity state is false result
    public async Task UpdateAsync(TEntity entity)
    {
        DbSet.Update(entity);
        await Task.CompletedTask;
    }

    public async Task UpdateRange(IEnumerable<TEntity> t)
    {
        foreach (var entity in t)
        {
            DbSet.Update(entity);
        }
        await Task.CompletedTask;
    }


    public async Task AddRange(IEnumerable<TEntity> t)
    {
        await DbSet.AddRangeAsync(t);
    }

    public async Task<IQueryable<TEntity>> FindAllAsyncAsQueryable(Expression<Func<TEntity, bool>> predicate)
    {
        return await Task.FromResult(DbSet.Where(predicate).AsQueryable());
    }

    public async Task<IQueryable<TEntity>> GetAllAsyncAsQueryable()
    {
        return await Task.FromResult(DbSet.AsQueryable());
    }
}

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace pdksApi.Core.DataAccess.Repository
{
    public class GenericRepositoryBase<TEntity, TContext> : IGenericRepositoryBase<TEntity>
        where TEntity : class, new() where TContext : DbContext, new()
    {
        #region Get Method
        public IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> filter = null)
        {
            var context = new TContext();
            return filter != null
                ? context.Set<TEntity>().Where(filter).AsQueryable().AsNoTracking()
                : context.Set<TEntity>().AsQueryable().AsNoTracking();
        }

        public IQueryable<TEntity> GetIncludable(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            var context = new TContext();
            var query = context.Set<TEntity>().AsNoTracking().AsQueryable();
            if (include != null)
            {
                query = include(query);
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query;
        }
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            await using var context = new TContext();
            try
            {
                return await context.Set<TEntity>().Where(filter).FirstAsync();
            }
            catch 
            {
                return await context.Set<TEntity>().Where(filter).FirstOrDefaultAsync();
            }           
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            await using var context = new TContext();
            return filter != null
                ? await context.Set<TEntity>().Where(filter).ToListAsync()
                : await context.Set<TEntity>().ToListAsync();
        }

        public async Task<int> GetCountAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            await using var context = new TContext();
            return filter == null ? await context.Set<TEntity>().CountAsync() :
                await context.Set<TEntity>().Where(filter).CountAsync();
        }

        #endregion
        #region Set Method
        public async Task<bool> Add(TEntity entity)
        {
            await using var context = new TContext();
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            var result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> Update(TEntity entity)
        {
            await using var context = new TContext();
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            var result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> Delete(TEntity entity)
        {
            await using var context = new TContext();
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Deleted;
            var result = await context.SaveChangesAsync();
            return result > 0;
        }
        #endregion


    }
}

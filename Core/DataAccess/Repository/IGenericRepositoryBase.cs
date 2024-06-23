using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace pdksApi.Core.DataAccess.Repository
{
    public interface IGenericRepositoryBase<TEntity> where TEntity : class, new()
    {
        #region Get method
        IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> filter);

        IQueryable<TEntity> GetIncludable(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null);
        Task<int> GetCountAsync(Expression<Func<TEntity, bool>> expression = null);
        #endregion

        #region Set Method
        Task<bool> Add(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(TEntity entity);
        #endregion
    }
}

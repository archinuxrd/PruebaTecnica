using System;
using System.Linq;
using Tec.Web.Core;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Tec.Web.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        #region Methods
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression);
        Task<ICollection<TEntity>> AllAsync(Expression<Func<TEntity, bool>> expression);

        Task<ICollection<TEntity>> AllAsync(Expression<Func<TEntity, bool>> expression, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, string includeProperties = null);

        Task<ICollection<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, Task<IQueryable<TEntity>>> func = null);
        
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression);

        Task<TEntity> GetByIdAsync(int id);

        Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> expression, string includeProperties = null);

        TEntity Add(TEntity entity);

        void Update(TEntity entity);

        Task DeleteAsync(int id);
        
        void Delete(TEntity entity);

        Task DeleteCombinationsAsync(ICollection<TEntity> entities);

        Task<int> GetTotalRecords();
        
        Task<ICollection<TEntity>> GetAllCombinationsByPatternIdAsync(int id);
        #endregion
        
        IQueryable<TEntity> Table { get; }
    }
}
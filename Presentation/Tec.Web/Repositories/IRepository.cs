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

        Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> expression, string includeProperties = null);

        TEntity Add(TEntity entity);

        Task<TEntity> GetByIdAsync(int id);

        void Update(TEntity entity);

        Task DeleteAsync(int id);
        
        void Delete(TEntity entity);

        Task DeleteCombinationsAsync(ICollection<TEntity> entities);
        
        Task<ICollection<TEntity>> GetAllCombinationsByPatternIdAsync(int id);
        #endregion
        
        #region Properties
        IQueryable<TEntity> Table { get; }
        #endregion
    }
}
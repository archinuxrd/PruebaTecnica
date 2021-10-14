using System;
using System.Linq;
using Tec.Web.Core;
using Tec.Web.Data;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Tec.Web.Repositories
{
    public class EntityRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        #region Fields
        private readonly ApplicationDbContext _db;
        #endregion

        #region Ctor
        public EntityRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        #endregion

        #region Methods
        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _db.Set<TEntity>().AnyAsync(expression);
        }

        public virtual async Task<ICollection<TEntity>> AllAsync(Expression<Func<TEntity, bool>> expression)
        {
            if (expression == null)
            {
                return await _db.Set<TEntity>().AsNoTracking().ToListAsync();
            }
            return await _db.Set<TEntity>().Where(expression).AsNoTracking().ToListAsync();
        }

        public virtual async Task<List<TEntity>> AllAsync()
        {
            return await _db.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<ICollection<TEntity>> AllAsync(Expression<Func<TEntity, bool>> expression, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, string includeProperties = null)
        {
            IQueryable<TEntity> query = _db.Set<TEntity>();
            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperties);
                }
            }
            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            return await query.ToListAsync();
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _db.Set<TEntity>().FirstOrDefaultAsync(expression);
        }
        
        public virtual async Task<ICollection<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, Task<IQueryable<TEntity>>> func = null)
        {
            async Task<ICollection<TEntity>> GetAllEntityAsync()
            {
                var query = Table;
                query = func != null ? await func(query) : query;
                return await query.ToListAsync();
            }
            return await GetAllEntityAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _db.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> expression, string includeProperties = null)
        {
            IQueryable<TEntity> query = Table;
            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return await query.FirstOrDefaultAsync();
        }

        public virtual TEntity Add(TEntity entity)
        {
            _db.Set<TEntity>().Add(entity);
            return entity;
        }

        public void Update(TEntity entity)
        {
            _db.Set<TEntity>().Update(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _db.Set<TEntity>().Remove(entity);
        }

        public virtual async Task Delete(int id)
        {
            var entity = await GetByIdAsync(id);
            _db.Set<TEntity>().Remove(entity);
        }
        
        public virtual void Delete(TEntity entity)
        {
            _db.Set<TEntity>().Remove(entity);
        }
        
        public virtual async Task DeleteCombinationsAsync(ICollection<TEntity> combinations)
        {
            if (combinations == null)
                throw new ArgumentNullException(nameof(combinations));

            foreach (var combination in combinations)
            {
                _db.Set<TEntity>().Remove(combination);
                await Table.Where(p=>p.Id == combination.Id).ToListAsync();
            }
        }
        
        public virtual async Task<ICollection<TEntity>> GetAllCombinationsByPatternIdAsync(int id)
        {
            var query = Table;
            return await query.Where(c => c.Id == id)
                        .OrderBy(c => c.Id)
                        .ThenBy(c => c.Id)
                        .ToListAsync();
        }

        public virtual async Task<int> GetTotalRecords()
        {
            var total = await _db.Set<TEntity>().CountAsync();
            return total;
        }
        #endregion
        
        #region Properties
        public virtual IQueryable<TEntity> Table => _db.Set<TEntity>();
        #endregion
    }
}
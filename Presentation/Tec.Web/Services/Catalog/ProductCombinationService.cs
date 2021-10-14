using System;
using AutoMapper;
using System.Linq;
using Tec.Web.Repositories;
using Tec.Web.Models.Catalog;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Tec.Web.Services.Catalog
{
    public class ProductCombinationService : IProductCombinationService
    {
        
        #region Fields
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public ProductCombinationService(IUnitOfWork db,
            IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        #endregion
        
        #region Methods
        public async Task<CombinationViewModel> AddAsync(CombinationViewModel viewModel)
        {
            _db.Combinations.Add(_mapper.Map<Combination>(viewModel));
            await _db.CompleteAsync();
            return viewModel;
        }
        
        public async Task<ICollection<CombinationViewModel>> GetAllAsync(Expression<Func<CombinationViewModel, bool>> expression = null, Func<IQueryable<CombinationViewModel>, IOrderedQueryable<CombinationViewModel>> orderBy = null, string includeProperties = null)
        {
            IQueryable<Combination> query = Table;
            if (expression != null)
            {
                var mapExpression = _mapper.Map<Expression<Func<Combination, bool>>>(expression);
                query = query.Where(mapExpression);
            }
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return _mapper.Map<ICollection<CombinationViewModel>>(await query.ToListAsync()); 
        }

        public async Task<int> DeleteCombinationAsync(CombinationViewModel model)
        {
            if (model != null)
            {
                await _db.Combinations.DeleteAsync(model.Id);
            }
            return await _db.CompleteAsync();
        }
        
        public async Task<int> UpdateAsync(CombinationViewModel viewModel)
        {
            var model = _mapper.Map<Combination>(viewModel);
            _db.Combinations.Update(model);
            return await _db.CompleteAsync();
        }
        #endregion
        
        #region Properties

        public IQueryable<Combination> Table => _db.Combinations.Table;
        #endregion
    }
}
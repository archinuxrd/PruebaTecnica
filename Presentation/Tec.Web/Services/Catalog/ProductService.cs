using System;
using System.Linq;
using Tec.Web.Repositories;
using System.Threading.Tasks;
using Tec.Web.Models.Catalog;
using System.Linq.Expressions;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tec.Web.Data;

namespace Tec.Web.Services.Catalog
{
    public sealed class ProductService : IProductService
    {
        #region Fields
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public ProductService(IUnitOfWork db,
            IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        #endregion
        
        #region Methods
        public async Task<ProductViewModel> AddAsync(ProductViewModel model)
        {
            var viewModel = _mapper.Map<Product>(model);
            _db.Products.Add(viewModel);
            await _db.CompleteAsync();
            return model;
        }

        public async Task<bool> AnyAsync(Expression<Func<ProductViewModel, bool>> expression)
        {
            var viewExpression = _mapper.Map<Expression<Func<Product, bool>>>(expression);
            return await _db.Products.AnyAsync(viewExpression);
        }

        public async Task<ProductViewModel> FirstByIdAsync(int id, string includeProperties = null)
        {
            var product =await _db.Products.FirstAsync(p=>p.Id == id, includeProperties);
            return _mapper.Map<ProductViewModel>(product);
        }

        public async Task<ProductViewModel> FirstAsync(ProductViewModel model, string includeProperties = null)
        {
            var product =await _db.Products.FirstAsync(p=>p.Id == model.Id, includeProperties);
            return _mapper.Map<ProductViewModel>(product);
        }

        public async Task<ProductViewModel> UpdateAsync(ProductViewModel viewModel)
        {
            _db.Products.Update(_mapper.Map<Product>(viewModel));
            await _db.CompleteAsync();
            return viewModel;
        }
        
        public async Task<int> DeleteAsync(ProductViewModel product)
        {
            var viewmodel = _mapper.Map<Product>(product);
            switch (viewmodel)
            {
                case null:
                    throw new ArgumentNullException(nameof(viewmodel));
                default:
                    _db.Products.Delete(viewmodel);
                    break;
            }
            return await _db.CompleteAsync();
        }
        
        public async Task DeleteCombinationsAsync(IList<Combination> combinations)
        {
            if (combinations == null)
            {
                throw new ArgumentNullException(nameof(combinations));
            }
            foreach (var combination in combinations)
            {
                _db.Combinations.Delete(combination);
            }
            await _db.CompleteAsync();
        }
        
        public async Task<ICollection<ProductViewModel>> GetAllAsync(Expression<Func<ProductViewModel, bool>> expression = null, Func<IQueryable<ProductViewModel>, IOrderedQueryable<ProductViewModel>> orderBy = null, string includeProperties = null)
        {
            IQueryable<Product> query = Table;
            if (expression != null)
            {
                var mapExpression = _mapper.Map<Expression<Func<Product, bool>>>(expression);
                query = query.Where(mapExpression);
            }
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return _mapper.Map<ICollection<ProductViewModel>>(await query.ToListAsync()); 
        }
        
        public async Task<ICollection<CombinationViewModel>> GetAllCombinationsByProductIdAsync(int productId)
        {
            var query = _mapper.Map<IQueryable<CombinationViewModel>>(_db.Combinations.Table);
            return await query.Where(x=>x.ProductId == productId)
                        .OrderBy(x=>x.Color)
                        .ThenBy(x=>x.Id).ToListAsync();
        }
        
        public async Task<int> DeleteProductAsync(ProductViewModel product)
        {
            if (product != null)
            {
                var viewModel = _mapper.Map<Product>(product);
                var combinations = await _db.Combinations.GetAllCombinationsByPatternIdAsync(viewModel.Id);
                if (combinations != null)
                {
                    await _db.Combinations.DeleteCombinationsAsync(combinations);
                }
                _db.Products.Delete(viewModel);
            }
            return await _db.CompleteAsync();
        }
        #endregion
        
        #region Properties
        public IQueryable<Product> Table => _db.Products.Table;
        #endregion
    }
}
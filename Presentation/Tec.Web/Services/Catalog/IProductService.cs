using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tec.Web.Models.Catalog;

namespace Tec.Web.Services.Catalog
{
    public partial interface IProductService
    {
        Task<ProductViewModel> AddAsync(ProductViewModel model);
        Task<bool> AnyAsync(Expression<Func<ProductViewModel, bool>> expression);
        Task<ProductViewModel> FirstByIdAsync(int id, string includeProperties = null);
        Task<ProductViewModel> FirstAsync(ProductViewModel model, string includeProperties = null);

        Task<ICollection<ProductViewModel>> GetAllAsync(
            Expression<Func<ProductViewModel, bool>> expression = null,
            Func<IQueryable<ProductViewModel>, IOrderedQueryable<ProductViewModel>> orderBy = null,
            string includeProperties = null);

        Task<ProductViewModel> UpdateAsync(ProductViewModel viewModel);
        Task<int> DeleteProductAsync(ProductViewModel product);
        Task<ICollection<CombinationViewModel>> GetAllCombinationsByProductIdAsync(int productId);
        IQueryable<Product> Table { get; }
    }
}
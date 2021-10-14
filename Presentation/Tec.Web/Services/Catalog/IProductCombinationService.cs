using System;
using System.Linq;
using Tec.Web.Models.Catalog;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Tec.Web.Services.Catalog
{
    public interface IProductCombinationService
    {
        Task<CombinationViewModel> AddAsync(CombinationViewModel viewModel);
        Task<int> DeleteCombinationAsync(CombinationViewModel viewModel);
        Task<ICollection<CombinationViewModel>> GetAllAsync(
            Expression<Func<CombinationViewModel, bool>> expression = null,
            Func<IQueryable<CombinationViewModel>, IOrderedQueryable<CombinationViewModel>> orderBy = null,
            string includeProperties = null);
        Task<int> UpdateAsync(CombinationViewModel viewModel);
        IQueryable<Combination> Table { get; }
    }
}
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tec.Web.Models.Catalog;

namespace Tec.Web.Services
{
    public interface IProductService
    {
        public Product Add();
        public Task<bool> AnyAsync(Expression<Func<Product, bool>> expression);
        public Task<Product> AllAsync(Expression<Func<Product, bool>> expression);
        public Task<Product> AllAsync();
        public Task<Product> FirstAsync();
        public Task<Product> GetByIdAsync();
        public Task<int> GetTotalRecords();
        public Product Update();
        public Task Delete();
    }
}
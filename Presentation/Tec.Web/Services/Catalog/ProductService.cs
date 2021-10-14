using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tec.Web.Models.Catalog;

namespace Tec.Web.Services
{
    public class ProductService : IProductService
    {
        public Product Add()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AnyAsync(Expression<Func<Product, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> AllAsync(Expression<Func<Product, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> AllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Product> FirstAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetByIdAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetTotalRecords()
        {
            throw new NotImplementedException();
        }

        public Product Update()
        {
            throw new NotImplementedException();
        }

        public Task Delete()
        {
            throw new NotImplementedException();
        }
    }
}
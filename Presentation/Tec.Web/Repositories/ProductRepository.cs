using Tec.Web.Data;
using Tec.Web.Models.Catalog;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Tec.Web.Repositories
{
    public class ProductRepository : EntityRepository<Product>, IProductRepository
    {
        #region Fields
        private readonly ApplicationDbContext _db;
        #endregion

        #region Ctor
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        #endregion
    }
}
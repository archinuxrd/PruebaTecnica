using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tec.Web.Data;
using Tec.Web.Models.Catalog;

namespace Tec.Web.Repositories
{
    public class ProductCombinationRepository : EntityRepository<ProductCombination>, IProductCombinationRepository
    {
        #region Fields
        private readonly ApplicationDbContext _db;
        #endregion

        #region Ctor
        public ProductCombinationRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        #endregion
    }
}
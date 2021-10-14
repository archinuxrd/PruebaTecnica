using Tec.Web.Data;
using Tec.Web.Models.Catalog;

namespace Tec.Web.Repositories
{
    public class CombinationRepository : EntityRepository<Combination>, ICombinationRepository
    {
        #region Fields
        private readonly ApplicationDbContext _db;
        #endregion

        #region Ctor
        public CombinationRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        #endregion
    }
}
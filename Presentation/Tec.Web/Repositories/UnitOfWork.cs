using System;
using Tec.Web.Data;
using System.Threading.Tasks;

namespace Tec.Web.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields
        private readonly ApplicationDbContext _db;
        #endregion

        #region Properties
        public IProductRepository Products { get; private set; }
        public ICombinationRepository Combinations { get; private set; }
        #endregion

        #region Ctor
        public UnitOfWork(
            ApplicationDbContext db,
            IProductRepository productRepository,
            ICombinationRepository combinationRepository)
        {
            _db = db;
            Products = productRepository;
            Combinations = combinationRepository;
        }
        #endregion

        #region Methods
        public async Task<int> CompleteAsync()
        {
            return await _db.SaveChangesAsync();
        }
        public void Dispose()
        {
            Dispose(true);
            // ReSharper disable once GCSuppressFinalizeForTypeWithoutDestructor
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
        }
        #endregion
    }
}
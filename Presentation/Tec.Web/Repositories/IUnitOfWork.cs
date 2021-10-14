using System;
using System.Threading.Tasks;

namespace Tec.Web.Repositories
{
        public interface IUnitOfWork : IDisposable
        {
            #region Methods
            IProductRepository Products { get; }

            ICombinationRepository Combinations { get; }

            Task<int> CompleteAsync();
            #endregion
        }
}
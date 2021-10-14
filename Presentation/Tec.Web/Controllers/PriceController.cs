using System.Linq;
using Tec.Web.Repositories;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace Tec.Web.Controllers
{
    public class PriceController : Controller
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Ctro
        public PriceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        
        [HttpPost]
        [ActionName("Product/Details")]
        public async Task<JsonResult> GetAsync()
        {
            var result = _unitOfWork.Products.AllAsync(null);
            var data = new
            {
                Items = await result,
                TotalCounts = result.Result.Count()
            };
            return new JsonResult(data);
        }
        #endregion
    }
}
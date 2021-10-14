using Tec.Web.Helper;
using Tec.Web.Models.Catalog;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tec.Web.Services.Catalog;
using Microsoft.Extensions.Logging;

namespace Tec.Web.Controllers
{
    [Route("Combination")]
    public class ProductCombinationController : Controller
    {
        private readonly IProductCombinationService _productCombinationService;
        private readonly ILogger<ProductCombinationController> _logger;

        public ProductCombinationController(IProductCombinationService productCombinationService,
            ILogger<ProductCombinationController> logger)
        {
            _productCombinationService = productCombinationService;
            _logger = logger;
        }

        [HttpPost]
        [Route("")]
        public async Task<JsonResult> GetAsync()
        {
            var combinations = await _productCombinationService.GetAllAsync();
            return new JsonResult(combinations);
        }
        
        [HttpPost]
        [Route("Create")]
        public async Task<JsonResult> CreateAsync(CombinationViewModel model)
        {
            if (model != null)
            {
                await _productCombinationService.AddAsync(model);
            }
            var combinations = await _productCombinationService.GetAllAsync(includeProperties: "Product");
            return new JsonResult(combinations);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<JsonResult> UpdateAsync(CombinationViewModel model)
        {
            if (model != null)
            {
                await _productCombinationService.UpdateAsync(model);
            }
            var combinations = await _productCombinationService.GetAllAsync(includeProperties: "Product");
            return new JsonResult(combinations);
        }
        
        [HttpDelete]
        [Route("Delete")]
        public async Task<JsonResult> DeleteAsync(CombinationViewModel model)
        {
            if (model != null)
            {
                await _productCombinationService.DeleteCombinationAsync(model);
            }
            var combinations = await _productCombinationService.GetAllAsync(includeProperties: "Product");
            return new JsonResult(combinations);
        }
        
        [Route("Color")]
        public JsonResult Color()
        {
            return new JsonResult(CommonHelper.GetAllColors());
        }
    }
}
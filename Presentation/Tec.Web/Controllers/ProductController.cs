using Tec.Web.Models.Catalog;
using Tec.Web.Models.Message;
using System.Threading.Tasks;
using Tec.Web.Services.Catalog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace Tec.Web.Controllers
{
    [Route("Product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService,
            ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        public async Task<JsonResult> GetAsync()
        {
            var data = await _productService.GetAllAsync(null, includeProperties: "Combinations");
            return new JsonResult(data);
        }
        
        [Route("Details/{id:int}")]
        public async Task<IActionResult> DetailsAsync(int id)
        {
            var result = await _productService.FirstByIdAsync(id, "Combinations");
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }
        
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteAsync(ProductViewModel model)
        {
            await _productService.DeleteProductAsync(model);
            return new JsonResult(new MessageViewModel
            {
                Success = true,
                Message = "Product was successfully deleted!"
            });
        }
        
        [HttpPost]
        [Route("Create")]
        public async Task<JsonResult> CreateAsync(ProductViewModel model)
        {
            if (model != null)
            {
                await _productService.AddAsync(model);
            }
            return new JsonResult(new MessageViewModel
            {
                Success = true,
                Message = "The Product was successfully created!"
            });
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<JsonResult> EditAsync(ProductViewModel model)
        {
            if (model != null)
            {
                await _productService.UpdateAsync(model);
            }
            return new JsonResult(new MessageViewModel
            {
                Success = true,
                Message = "Product was successfully Edited!"
            });
        }
    }
}
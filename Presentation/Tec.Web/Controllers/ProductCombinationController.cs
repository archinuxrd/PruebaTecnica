using System;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Kendo.Mvc.UI;
using Microsoft.Extensions.Logging;
using Tec.Web.Models.Catalog;
using Tec.Web.Repositories;


namespace Tec.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IUnitOfWork unitOfWork,
            ILogger<ProductController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [Route("Product/Details/{id}")]
        public async Task<IActionResult> DetailsAsync(int id)
        {
            var result = await _unitOfWork.Products.FirstAsync(p => p.Id == id, "Combinations");
            var model = new ProductViewModel
            {
                Product = result,
                Combinations = result.Combinations
            };
            return View(model);
        }

        [HttpPost]
        [Route("Product")]
        public async Task<JsonResult> GetAsync()
        {
            var result = _unitOfWork.Products.AllAsync(includeProperties: "Combinations");
            var data = new
            {
                Items = await result,
                TotalCounts = result.Result.Count()
            };
            return new JsonResult(data);
        }
        
        [HttpPost]
        [Route("Product/Combinations")]
        public async Task<JsonResult> CombinationAsync()
        {
            var result = _unitOfWork.Combinations.AllAsync(includeProperties: "Product");
            var data = new
            {
                Items = await result,
                TotalCounts = result.Result.Count()
            };
            return new JsonResult(data);
        }

        [HttpPost]
        [Route("Product/Edit")]
        public async Task<JsonResult> EditAsync()
        {
            var result = _unitOfWork.Products.AllAsync(null, includeProperties: "Combinations");
            var data = new
            {
                Items = await result,
                TotalCounts = result.Result.Count()
            };
            return new JsonResult(data);
        }
    }
}
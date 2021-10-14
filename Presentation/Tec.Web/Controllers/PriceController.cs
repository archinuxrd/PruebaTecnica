using System;
using System.Linq;
using Tec.Web.Data;
using Tec.Web.Repositories;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace Tec.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PriceController : BaseApiController
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
        [ActionName("Get/{id}")]
        public async Task<OkObjectResult> GetAsync(int id)
        {
            return Ok(await _unitOfWork.Products.GetAsync(p => p.Id == id));
        }
        
        
        [ActionName("GetAll")]
        public async Task<OkObjectResult> GetAllAsync()
        {
            return Ok(await _unitOfWork.Products.GetAsync(p => p.Id == 1));
        }

        // public async Task<OkObjectResult> AllAsync()
        // {
        //     return await _unitOfWork.Products.AllAsync(null);
        // }
        #endregion
    }
}
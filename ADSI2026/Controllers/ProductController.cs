using Microsoft.AspNetCore.Mvc;
using MVC.Data.DTO.Product;
using MVC.Data.DTO.Supplier;
using MVC.Domain.Services;
using MVC.Domain.Services.Interfaces;

namespace ADSI2026.Controllers
{
    public class ProductController : Controller
    {
        #region Properties
        private readonly IProductServices _productServices; 
        #endregion

        #region Builder
        public ProductController(IProductServices productServices)
        {
            this._productServices = productServices;
        }
        #endregion


        #region Views
        public IActionResult Index()
        {
            return View();
        }
        #endregion

        #region Services

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            List<ProductDto> entities = await _productServices.GetAllProducts();
            return Ok(entities);
        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            bool success = await _productServices.DeleteProductAsync(id);
            return Ok(success);
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(AddProductDto add)
        {
            bool success = await _productServices.AddProductAsync(add);
            return Ok(success);
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto update)
        {
            bool success = await _productServices.UpdateProductAsync(update);
            return Ok(success);
        }

        #endregion
    }
}

using Microsoft.AspNetCore.Mvc;
using MVC.Data.DTO.Supplier;
using MVC.Domain.Services.Interfaces;

namespace ADSI2026.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierServices _supplierServices;

        public SupplierController(ISupplierServices supplierServices)
        {
            _supplierServices = supplierServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("GetAllSuppliers")]
        public async Task<IActionResult> GetAllSuppliers()
        {
            List<SupplierDto> entities = await _supplierServices.GetAllSuppliers();
            return Ok(entities);
        }

        [HttpDelete("DeleteSupplier")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            bool success = await _supplierServices.DeleteSupplierAsync(id);
            return Ok(success);
        }

        [HttpPost("AddSupplier")]
        public async Task<IActionResult> AddSupplier(AddSupplierDto add)
        {
            bool success = await _supplierServices.AddSupplierAsync(add);
            return Ok(success);
        }

        [HttpPut("UpdateSupplier")]
        public async Task<IActionResult> UpdateSupplier(UpdateSupplierDto update)
        {
            bool success = await _supplierServices.UpdateSupplierAsync(update);
            return Ok(success);
        }
    }
}

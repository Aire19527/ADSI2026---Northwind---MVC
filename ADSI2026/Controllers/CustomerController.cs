using Microsoft.AspNetCore.Mvc;
using MVC.Data.DTO.Customer;
using MVC.Data.Models;
using MVC.Domain.Services.Interfaces;

namespace ADSI2026.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerServices _customerServices;

        public CustomerController(ICustomerServices customerServices)
        {
            this._customerServices = customerServices;
        }

        public async Task<IActionResult> Index()
        {
           // var result = 

            return View();
        }

        [HttpGet("GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            List<Customer> entities = await _customerServices.GetAllCustomers();
            return Ok(entities);
        }


        [HttpGet("GetCustomer")]
        public async Task<IActionResult> GetCustomerAsync(string customerId)
        {
            Customer entity = await _customerServices.GetCustomerAsync(customerId);
            return Ok(entity);
        }

        [HttpDelete("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(string customerId)
        {
            bool success = await _customerServices.DeleteCustomersAsync(customerId);
            return Ok(success);
        }

        [HttpPost("AddCustomers")]
        public async Task<IActionResult> AddCustomersAsync([FromBody] AddCustomerDto customer)
        {
            bool success = await _customerServices.AddCustomersAsync(customer);
            return Ok(success);
        }

        [HttpPut("UpdateCustomers")]
        public async Task<IActionResult> UpdateCustomersAsync([FromBody] UpdateCustomerDto update)
        {
            bool success = await _customerServices.UpdateCustomersAsync(update);
            return Ok(success);
        }
    }
}

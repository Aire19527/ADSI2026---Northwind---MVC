using MVC.Data.DTO.Customer;
using MVC.Data.Models;

namespace MVC.Domain.Services.Interfaces
{
    public interface ICustomerServices
    {
        Task<Customer> GetCustomerAsync(string customerId);
        Task<List<Customer>> GetAllCustomers();
        Task<bool> AddCustomersAsync(AddCustomerDto customer);
        Task<bool> UpdateCustomersAsync(UpdateCustomerDto update);
        Task<bool> DeleteCustomersAsync(string customerId);

    }
}

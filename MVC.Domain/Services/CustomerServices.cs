using Microsoft.EntityFrameworkCore;
using MVC.Common.Exceptions;
using MVC.Data.Data;
using MVC.Data.DTO.Customer;
using MVC.Data.Models;
using MVC.Domain.Services.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MVC.Domain.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly NorthwindContext _context;
        public CustomerServices(NorthwindContext context)
        {
            this._context = context;
        }

        public async Task<Customer> GetCustomerAsync(string customerId)
        {
            var entity = await _context.Customers.FirstOrDefaultAsync(x => x.CustomerId == customerId);
            if (entity == null)
            {
                throw new Exception($"El customer con el ID {customerId} no existe, por favor revisar el id enviado.");
            }

            return entity;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            List<Customer> customers = await _context.Customers.ToListAsync();

            return customers;
        }

        public async Task<bool> AddCustomersAsync(AddCustomerDto add)
        {
            Customer entity = new Customer()
            {
                CustomerId = add.CustomerId,
                CompanyName = add.CompanyName,
                ContactName = add.ContactName,
                Phone = add.Phone,
                Country = add.Country,
            };

            _context.Customers.Add(entity);
            bool success = await _context.SaveChangesAsync() > 0;

            return success;
        }


        public async Task<bool> UpdateCustomersAsync(UpdateCustomerDto update)
        {
            Customer entity = await GetCustomerAsync(update.CustomerId);
            entity.CompanyName = update.CompanyName;
            entity.ContactName = update.ContactName;
            entity.Phone = update.Phone;
            entity.Country = update.Country;

            _context.Customers.Update(entity);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteCustomersAsync(string customerId)
        {
            Customer entity = await GetCustomerAsync(customerId);
            _context.Customers.Remove(entity);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}

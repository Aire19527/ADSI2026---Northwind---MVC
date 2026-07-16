using Microsoft.EntityFrameworkCore;
using MVC.Data.Data;
using MVC.Data.DTO.Supplier;
using MVC.Data.Models;
using MVC.Domain.Services.Interfaces;

namespace MVC.Domain.Services
{
    public class SupplierServices : ISupplierServices
    {
        #region Properties
        private readonly NorthwindContext _context; 
        #endregion

        #region Constructor
        public SupplierServices(NorthwindContext context)
        {
            this._context = context;
        }
        #endregion

        #region Methods
        public async Task<List<SupplierDto>> GetAllSuppliers()
        {
            List<Supplier> supplier = await _context.Suppliers.ToListAsync();
            List<SupplierDto> result = supplier.Select(x => new SupplierDto()
            {
                SupplierId = x.SupplierId,
                Address = x.Address,
                City = x.City,
                CompanyName = x.CompanyName,
                ContactName = x.ContactName,
                Country = x.Country,
                Phone = x.Phone,
            }).ToList();


            //foreach (var item in supplier)
            //{
            //    result.Add(new SupplierDto()
            //    {
            //        SupplierId = item.SupplierId,
            //        Address = item.Address,
            //        City = item.City,
            //        CompanyName = item.CompanyName,
            //        ContactName = item.ContactName,
            //        Country = item.Country,
            //        Phone = item.Phone,
            //    });
            //}


            return result;
        }

        public async Task<bool> AddSupplierAsync(AddSupplierDto add)
        {
            Supplier entity = new Supplier()
            {
                CompanyName = add.CompanyName,
                ContactName = add.ContactName,
                Address = add.Address,
                City = add.City,
                Phone = add.Phone,
                Country = add.Country,
            };

            _context.Suppliers.Add(entity);
            bool success = await _context.SaveChangesAsync() > 0;

            return success;
        }


        public async Task<bool> UpdateSupplierAsync(UpdateSupplierDto update)
        {
            Supplier entity = await GetSupplierAsync(update.SupplierId);
            entity.CompanyName = update.CompanyName;
            entity.ContactName = update.ContactName;
            entity.Address = update.Address;
            entity.City = update.City;
            entity.Phone = update.Phone;
            entity.Country = update.Country;

            _context.Suppliers.Update(entity);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteSupplierAsync(int id)
        {
            Supplier entity = await GetSupplierAsync(id);
            _context.Suppliers.Remove(entity);

            return await _context.SaveChangesAsync() > 0;
        }
        #endregion


        #region Privates
        private async Task<Supplier> GetSupplierAsync(int id)
        {
            var entity = await _context.Suppliers.FirstOrDefaultAsync(x => x.SupplierId == id);
            if (entity == null)
            {
                throw new Exception($"El Proveedor con el ID {id} no existe, por favor revisar el id enviado.");
            }

            return entity;
        } 
        #endregion
    }
}

using Microsoft.EntityFrameworkCore;
using MVC.Data.Data;
using MVC.Data.DTO.Product;
using MVC.Data.DTO.Supplier;
using MVC.Data.Models;
using MVC.Domain.Services.Interfaces;

namespace MVC.Domain.Services
{
    public class ProductServices : IProductServices
    {
        #region Properties
        private readonly NorthwindContext _context;
        #endregion

        #region Builder
        public ProductServices(NorthwindContext context)
        {
            this._context = context;
        }
        #endregion

        #region Methods
        public async Task<List<ProductDto>> GetAllProducts()
        {
            List<Product> prducts = await _context.Products
                                                  .Include(x=>x.Supplier)
                                                  .Include(x=>x.Category)
                                                  .ToListAsync();
            List<ProductDto> result = prducts.Select(x => new ProductDto()
            {
                CategoryId = (int)x.CategoryId!,
                SupplierId = (int)x.SupplierId!,
                ProductName = x.ProductName,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitsInStock,
                ProductId = x.ProductId,
                Category = x.Category.CategoryName,
                Supplier = x.Supplier.CompanyName,

            }).ToList();

            return result;
        }

        public async Task<bool> AddProductAsync(AddProductDto add)
        {
            Product entity = new Product()
            {
                CategoryId = add.CategoryId,
                SupplierId = add.SupplierId,
                ProductName = add.ProductName,
                UnitPrice = add.UnitPrice,
                UnitsInStock = add.UnitsInStock,
            };

            _context.Products.Add(entity);
            bool success = await _context.SaveChangesAsync() > 0;

            return success;
        }


        public async Task<bool> UpdateProductAsync(UpdateProductDto update)
        {
            Product entity = await GetProductAsync(update.ProductId);
            entity.CategoryId = update.CategoryId;
            entity.SupplierId = update.SupplierId;
            entity.ProductName = update.ProductName;
            entity.UnitPrice = update.UnitPrice;
            entity.UnitsInStock = update.UnitsInStock;

            _context.Products.Update(entity);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            Product entity = await GetProductAsync(id);
            _context.Products.Remove(entity);

            return await _context.SaveChangesAsync() > 0;
        }
        #endregion


        #region Privates
        private async Task<Product> GetProductAsync(int id)
        {
            var entity = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);
            if (entity == null)
            {
                throw new Exception($"El Producto con el ID {id} no existe, por favor revisar el id enviado.");
            }

            return entity;
        }
        #endregion

    }
}

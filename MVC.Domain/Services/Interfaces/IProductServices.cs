using MVC.Data.DTO.Product;

namespace MVC.Domain.Services.Interfaces
{
    public interface IProductServices
    {
        Task<List<ProductDto>> GetAllProducts();

        Task<bool> AddProductAsync(AddProductDto add);

        Task<bool> UpdateProductAsync(UpdateProductDto update);
        Task<bool> DeleteProductAsync(int id);
    }
}

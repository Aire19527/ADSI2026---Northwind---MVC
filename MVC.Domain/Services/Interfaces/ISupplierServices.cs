using MVC.Data.DTO.Supplier;
using MVC.Data.Models;

namespace MVC.Domain.Services.Interfaces
{
    public interface ISupplierServices
    {
        Task<List<SupplierDto>> GetAllSuppliers();

        Task<bool> AddSupplierAsync(AddSupplierDto add);


        Task<bool> UpdateSupplierAsync(UpdateSupplierDto update);

        Task<bool> DeleteSupplierAsync(int id);
    }
}

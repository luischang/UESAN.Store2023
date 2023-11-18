using UESAN.Store.CORE.Entities;

namespace UESAN.Store.CORE.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);
        Task<bool> Insert(Product product);
        Task<bool> ExistsDescription(string description);
        Task<IEnumerable<Product>> GetAllByCategory(int? categoryId);
    }
}

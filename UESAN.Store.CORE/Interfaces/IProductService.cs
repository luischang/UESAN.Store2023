using UESAN.Store.CORE.DTOs;

namespace UESAN.Store.CORE.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductCategoryDTO>> GetAll();
        Task<ProductCategoryDTO> GetById(int id);
        Task<bool> Insert(ProductInsertDTO productInsert);
        Task<IEnumerable<ProductCategoryDTO>> GetAllByCategory(int? categoryId);

    }
}

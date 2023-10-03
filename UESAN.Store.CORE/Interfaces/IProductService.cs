using UESAN.Store.CORE.DTOs;

namespace UESAN.Store.CORE.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDescriptionDTO>> GetAll();
        Task<ProductDescriptionDTO> GetById(int id);
        Task<bool> Insert(ProductInsertDTO productInsert);
    }
}

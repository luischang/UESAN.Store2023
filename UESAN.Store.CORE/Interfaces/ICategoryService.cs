using UESAN.Store.CORE.DTOs;

namespace UESAN.Store.CORE.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDescriptionDTO>> GetAll();
        Task<CategoryDescriptionDTO> GetById(int id);
        Task<bool> Insert(CategoryInsertDTO categoryInsert);
    }
}
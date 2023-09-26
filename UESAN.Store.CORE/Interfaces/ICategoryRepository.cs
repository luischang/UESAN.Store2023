using UESAN.Store.CORE.Entities;

namespace UESAN.Store.CORE.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAll();
        Task<Category> GetById(int id);
        Task<bool> Insert(Category category);
        Task<bool> ExistsDescription(string description);
    }
}
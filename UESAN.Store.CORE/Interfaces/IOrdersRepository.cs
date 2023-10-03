
using UESAN.Store.CORE.Entities;

namespace UESAN.Store.CORE.Interfaces
{
    public interface IOrdersRepository
    {
        Task<IEnumerable<Orders>> GetAllByUser(int userId);

        Task<int> Insert(Orders orders);
    }
}

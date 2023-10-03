
using UESAN.Store.CORE.DTOs;

namespace UESAN.Store.CORE.Interfaces
{
    public interface IOrdersService
    {
        Task<IEnumerable<OrdersDTO>> GetAllByUser(int userId);
        Task<int> Insert(OrdersInsertDTO ordersDTO);
    }
}


using UESAN.Store.CORE.Entities;

namespace UESAN.Store.CORE.Interfaces
{
    public interface IOrdersDetailsRepository
    { 
        Task<bool> Insert(IEnumerable<OrderDetail> orderDetails);
    }
}

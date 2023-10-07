using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Store.CORE.Entities;

namespace UESAN.Store.CORE.Interfaces
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> GetAll();
        Task<Payment> GetById(int id);
        Task<bool> Insert(Payment payment);
       
        Task<bool> ExistsPaymentMethod(string paymentMethod);
    }
}

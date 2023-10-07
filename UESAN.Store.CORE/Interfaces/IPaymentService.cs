using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Store.CORE.DTOs;

namespace UESAN.Store.CORE.Interfaces
{
    public interface IPaymentService
    {
        Task<IEnumerable<PaymentMethodDescriptionDTO>> GetAll();
        Task<PaymentMethodDescriptionDTO> GetById(int id);
        Task<bool> Insert(PaymentInsertDTO paymentInsert);
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Store.CORE.DTOs;
using UESAN.Store.CORE.Entities;
using UESAN.Store.CORE.Interfaces;

namespace UESAN.Store.CORE.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public async Task<IEnumerable<PaymentMethodDescriptionDTO>> GetAll()
        {
            var payments = await _paymentRepository.GetAll();
            var paymentsDTO = new List<PaymentMethodDescriptionDTO>();
            //Pasar todas las categorias
            //al dto (IEnumerable<Payment> ---> IEnumerable<PaymentMethod>

            foreach (var payment in payments)
            {
                var paymentDTO = new PaymentMethodDescriptionDTO();
                paymentDTO.Id = payment.Id;
                paymentDTO.PaymentMethod = payment.PaymentMethod;
                paymentDTO.Status = payment.Status;
                paymentDTO.TotalAmount = payment.TotalAmount;
                paymentDTO.OrdersId = payment.OrdersId;



                paymentsDTO.Add(paymentDTO);
            }
            return paymentsDTO;
        }

        public async Task<PaymentMethodDescriptionDTO> GetById(int id)
        {
            var payment = await _paymentRepository.GetById(id);
            var paymentDTO = new PaymentMethodDescriptionDTO()
            {
                Id = payment.Id,
                PaymentMethod = payment.PaymentMethod,
                Status = payment.Status,
                TotalAmount = payment.TotalAmount,
                OrdersId = payment.OrdersId,
            };
            return paymentDTO;
        }

        public async Task<bool> Insert(PaymentInsertDTO paymentInsert)
        {
            var exists = await _paymentRepository.ExistsPaymentMethod(paymentInsert.PaymentMethod);
            if (!exists)
            {
                var payment = new Payment();
                payment.PaymentMethod = paymentInsert.PaymentMethod;
                payment.Status = paymentInsert.Status;
                payment.TotalAmount = paymentInsert.TotalAmount;
                payment.OrdersId = paymentInsert.OrdersId;
                
                
              
                return await _paymentRepository.Insert(payment);
            }
            return false;
        }
        


    }
}

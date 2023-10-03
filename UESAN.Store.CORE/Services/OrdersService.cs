using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using UESAN.Store.CORE.DTOs;
using UESAN.Store.CORE.Entities;
using UESAN.Store.CORE.Interfaces;

namespace UESAN.Store.CORE.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;

        private readonly IOrdersDetailsRepository _ordersDetailsRepository;

        public OrdersService(IOrdersRepository ordersRepository, IOrdersDetailsRepository ordersDetailsRepository)
        {
            _ordersRepository = ordersRepository;
            _ordersDetailsRepository = ordersDetailsRepository;
        }

        public async Task<IEnumerable<OrdersDTO>> GetAllByUser(int userId)
        {
            var orders = await _ordersRepository.GetAllByUser(userId);
            if (!orders.Any())
                return null;

            var ordesDTO = new List<OrdersDTO>();
            foreach (var order in orders)
            {
                var orderDTO = new OrdersDTO()
                {
                    Id = order.Id,
                    Status = order.Status,
                    TotalAmount = order.TotalAmount
                };
                ordesDTO.Add(orderDTO);
            }
            return ordesDTO;
        }
        public async Task<int> Insert(OrdersInsertDTO ordersDTO)
        {
            var orders = new Orders()
            {
                UserId = ordersDTO.UserId,
                CreatedAt = DateTime.Now,
                Status = "A",
                TotalAmount = 0
            };
            var resultOrderId = await _ordersRepository.Insert(orders);

            var orderDetailList = new List<OrderDetail>();
            foreach (var item in ordersDTO.OrderDetail)
            {
                var orderDetail = new OrderDetail()
                {
                    OrdersId = resultOrderId,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    CreatedAt = DateTime.Now,
                    ProductId = item.ProductId,
                };
                orderDetailList.Add(orderDetail);
            }
            await _ordersDetailsRepository.Insert(orderDetailList);
            return resultOrderId;

        }
    }
}

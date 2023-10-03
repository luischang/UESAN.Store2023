using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Store.CORE.Entities;
using UESAN.Store.CORE.Interfaces;
using UESAN.Store.INFRASTRUCTURE.Data;

namespace UESAN.Store.INFRASTRUCTURE.Repositories
{
    public class OrdersDetailsRepository : IOrdersDetailsRepository
    {
        private readonly StoreDbContext _dbContext;

        public OrdersDetailsRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Insert(IEnumerable<OrderDetail> orderDetails)
        {
            await _dbContext.OrderDetail.AddRangeAsync(orderDetails);
            var totalAmount = orderDetails.Sum(x => x.Quantity * x.Price);

            var order = await _dbContext.Orders.Where(x => x.Id == orderDetails.FirstOrDefault().OrdersId).FirstOrDefaultAsync();

            order.TotalAmount = totalAmount;
            _dbContext.Orders.Update(order);

            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}

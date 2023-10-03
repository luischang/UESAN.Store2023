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
    public class OrdersRepository : IOrdersRepository
    {
        private readonly StoreDbContext _dbContext;

        public OrdersRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Insert(Orders orders)
        {
            await _dbContext.Orders.AddAsync(orders);
            await _dbContext.SaveChangesAsync();
            return orders.Id;
        }
        public async Task<IEnumerable<Orders>> GetAllByUser(int UserId)
        {
            return await _dbContext.Orders.Where(x => x.UserId == UserId).ToListAsync();
        }
    }
}

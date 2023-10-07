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
    public class PaymentRepository : IPaymentRepository
    {
        private readonly StoreDbContext _dbContext;
        public PaymentRepository(StoreDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Payment>> GetAll()
        {
            return await _dbContext.Payment.ToListAsync();
        }
        public async Task<Payment> GetById(int id)
        {
            return await _dbContext
                .Payment
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Payment payment)
        {
            await _dbContext.Payment.AddAsync(payment);
            var countRows = await _dbContext.SaveChangesAsync();
            return countRows > 0;
        }
        

        public async Task<bool> ExistsPaymentMethod(string paymentMethod)
        {
            return await _dbContext
                 .Payment
                 .Where(x => x.PaymentMethod == paymentMethod.Trim()).AnyAsync();

        }

    }
}

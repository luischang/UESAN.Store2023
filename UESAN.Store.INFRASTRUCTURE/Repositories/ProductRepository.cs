using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Store.CORE.Entities;
using UESAN.Store.CORE.Interfaces;
using UESAN.Store.INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace UESAN.Store.INFRASTRUCTURE.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _dbContext;

        public ProductRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _dbContext.Product.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _dbContext
                .Product
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Product product)
        {
            await _dbContext.Product.AddAsync(product);
            var countRows = await _dbContext.SaveChangesAsync();
            return countRows > 0;
        }

        public async Task<bool> ExistsDescription(string description)
        {
            return await _dbContext
                 .Product
                 .Where(x => x.Description == description.Trim()).AnyAsync();

        }
    }
}

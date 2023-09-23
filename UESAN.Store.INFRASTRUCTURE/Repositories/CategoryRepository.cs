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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreDbContext _dbContext;

        public CategoryRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _dbContext.Category.ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await _dbContext
                .Category
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Category category)
        {
            await _dbContext.Category.AddAsync(category);
            var countRows = await _dbContext.SaveChangesAsync();
            return countRows > 0;
        }

    }
}

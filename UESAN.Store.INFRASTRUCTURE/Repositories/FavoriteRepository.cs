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
	public class FavoriteRepository : IFavoriteRepository
	{
		private readonly StoreDbContext _dbContext;

		public FavoriteRepository(StoreDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IEnumerable<Favorite>> GetAll()
		{
			return await _dbContext.Favorite.ToListAsync();
		}

		public async Task<Favorite> GetById(int id)
		{
			return await _dbContext
				.Favorite
				.Where(x => x.Id == id).FirstOrDefaultAsync();
		}

		public async Task<bool> Consult(Favorite favorite)
		{
			await _dbContext.Favorite.AddAsync(favorite);
			var countRows = await _dbContext.SaveChangesAsync();
			return countRows > 0;
		}

		public async Task<bool> ExistsCreateAt(DateTime CreatedAt)
		{
			return await _dbContext
				 .Favorite
                 .Where(x => x.CreatedAt == CreatedAt.Trim()).AnyAsync();

		}

        public Task<bool> ExistsCreatedAt(DateTime CreatedAt)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsCreatedAt(DateTime? createdAt)
        {
            throw new NotImplementedException();
        }
    }
}

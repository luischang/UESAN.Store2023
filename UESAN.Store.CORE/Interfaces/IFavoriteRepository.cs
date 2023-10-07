using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UESAN.Store.CORE.Entities;

namespace UESAN.Store.CORE.Interfaces
{
	public interface IFavoriteRepository
	{
		Task<IEnumerable<Favorite>> GetAll();
		Task<Favorite> GetById(int id);
		Task<bool> Consult(Favorite favorite);
		Task<bool> ExistsCreatedAt(DateTime CreatedAt);
        Task<bool> ExistsCreatedAt(DateTime? createdAt);
    }
}

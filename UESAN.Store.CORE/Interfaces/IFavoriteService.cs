using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Store.CORE.DTOs;

namespace UESAN.Store.CORE.Interfaces
{
	public interface IFavoriteService
	{
        Task<bool> Consult(FavoriteConsultDTO favorite);
        Task<IEnumerable<FavoriteConsultDTO>> GetAll();
		Task<FavoriteConsultDTO> GetById(int id);
		Task<bool> Insert(FavoriteConsultDTO favoriteConsult);
	}
}

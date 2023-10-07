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
	public class FavoriteService : IFavoriteService
	{
		private readonly IFavoriteRepository _favoriteRepository;

		public FavoriteService(IFavoriteRepository favoriteRepository)
		{
			_favoriteRepository = favoriteRepository;
		}

		public async Task<IEnumerable<FavoriteConsultDTO>> GetAll()
		{
			var favorites = await _favoriteRepository.GetAll();
			var favoritesDTO = new List<FavoriteConsultDTO>();
			//Pasar todas los favoritos
			

			foreach (var favorite in favorites)
			{
				var favoriteDTO = new FavoriteConsultDTO();
				favoriteDTO.Id = favorite.Id;
				favoriteDTO.CreatedAt = favorite.CreatedAt;

				favoritesDTO.Add(favoriteDTO);
			}
			return favoritesDTO;
		}

		public async Task<FavoriteConsultDTO> GetById(int id)
		{
			var favorite = await _favoriteRepository.GetById(id);
			var favoriteDTO = new FavoriteConsultDTO()
			{
				Id = favorite.Id,
				CreatedAt = favorite.CreatedAt
			};
			return favoriteDTO;
		}

		public async Task<bool> Insert(FavoriteConsultDTO favoriteConsult)
		{
			var exists = await _favoriteRepository.ExistsCreatedAt(favoriteConsult.CreatedAt);
			if (!exists)
			{
				var favorite = new Favorite();
				favorite.Id = favoriteConsult.Id;
				favorite.CreatedAt = favoriteConsult.CreatedAt;
				favorite.IsActive = true;
				return await _favoriteRepository.Consult(favorite);
			}
			return false;
		}

        public Task<bool> Consult(FavoriteConsultDTO favoriteConsult)
        {
            throw new NotImplementedException();
        }
    }
}
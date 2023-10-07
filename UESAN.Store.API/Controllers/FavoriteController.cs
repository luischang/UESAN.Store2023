using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Store.CORE.DTOs;
using UESAN.Store.CORE.Entities;
using UESAN.Store.CORE.Interfaces;

namespace UESAN.Store.API.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
	public class FavoriteController : ControllerBase
	{
		
		private readonly IFavoriteService _favoriteService;

		
		public FavoriteController(IFavoriteService favoriteService)
		{
			
			_favoriteService = favoriteService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var result = await _favoriteService.GetAll();
			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var result = await _favoriteService.GetById(id);
			return Ok(result);
		}

		[HttpPost()]
		public async Task<IActionResult> Create(FavoriteConsultDTO favorite)
		{
			var result = await _favoriteService.Consult(favorite);
			if (!result)
				return BadRequest("Ocurrió un error");

			return Ok(result);
		}
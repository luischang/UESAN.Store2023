using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Store.CORE.Entities;
using UESAN.Store.CORE.Interfaces;

namespace UESAN.Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            var result = await _categoryRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _categoryRepository.GetById(id);
            return Ok(result);
        }

        [HttpPost()]
        public async Task<IActionResult> Create(Category category)
        {
            var result = await _categoryRepository.Insert(category);
            if(!result)
                BadRequest("Ocurrió un error");
            
            return Ok(result);
        }


    }
}

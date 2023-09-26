using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Store.CORE.DTOs;
using UESAN.Store.CORE.Entities;
using UESAN.Store.CORE.Interfaces;

namespace UESAN.Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        //private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryService _categoryService;

        //public CategoryController(ICategoryRepository categoryRepository)
        public CategoryController(ICategoryService categoryService)
        {
            //_categoryRepository = categoryRepository;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            var result = await _categoryService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _categoryService.GetById(id);
            return Ok(result);
        }

        [HttpPost()]
        public async Task<IActionResult> Create(CategoryInsertDTO category)
        {
            var result = await _categoryService.Insert(category);
            if(!result)
                return BadRequest("Ocurrió un error");
            
            return Ok(result);
        }


    }
}

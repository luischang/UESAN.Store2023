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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryDescriptionDTO>> GetAll()
        {
            var categories = await _categoryRepository.GetAll();
            var categoriesDTO = new List<CategoryDescriptionDTO>();
            //Pasar todas las categorias
            //al dto (IEnumerable<Category> ---> IEnumerable<CategoryDescription>

            foreach (var category in categories)
            {
                var categoryDTO = new CategoryDescriptionDTO();
                categoryDTO.Id = category.Id;
                categoryDTO.Description = category.Description;

                categoriesDTO.Add(categoryDTO);
            }
            return categoriesDTO;
        }

        public async Task<CategoryDescriptionDTO> GetById(int id)
        {
            var category = await _categoryRepository.GetById(id);
            var categoryDTO = new CategoryDescriptionDTO()
            {
                Id = category.Id,
                Description = category.Description
            };
            return categoryDTO;
        }

        public async Task<bool> Insert(CategoryInsertDTO categoryInsert)
        {
            var exists = await _categoryRepository.ExistsDescription(categoryInsert.Description);
            if (!exists)
            {
                var category = new Category();
                category.Description = categoryInsert.Description;
                category.IsActive = true;
                return await _categoryRepository.Insert(category);
            }
            return false;
        }

    }
}

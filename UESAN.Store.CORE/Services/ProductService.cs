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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductCategoryDTO>> GetAll()
        {
            var products = await _productRepository.GetAll();
            var productsDTO = new List<ProductCategoryDTO>();

            foreach (var product in products)
            {
                var productDTO = new ProductCategoryDTO();
                productDTO.Id = product.Id;
                productDTO.Description = product.Description;
                productDTO.Stock = product.Stock;
                productDTO.Price = product.Price;
                productDTO.ImageUrl = product.ImageUrl;
                productDTO.Discount = product.Discount;
                productDTO.Category = new CategoryDescriptionDTO()
                {
                    Id = product.Category.Id,
                    Description = product.Category.Description
                };

                productsDTO.Add(productDTO);
            }
            return productsDTO;
        }

        public async Task<ProductCategoryDTO> GetById(int id)
        {
            var product = await _productRepository.GetById(id);
            var productDTO = new ProductCategoryDTO()
            {
                Id = product.Id,
                Description = product.Description,
                Stock = product.Stock,
                Price = product.Price,
                Discount = product.Discount,
                Category = new CategoryDescriptionDTO()
                {
                    Id = product.Category.Id,
                    Description = product.Category.Description
                }
            };
            return productDTO;
        }

        public async Task<bool> Insert(ProductInsertDTO productInsert)
        {
            var exists = await _productRepository.ExistsDescription(productInsert.Description);
            if (!exists)
            {
                var product = new Product();
                product.Description = productInsert.Description;
                product.ImageUrl = productInsert.ImageUrl;
                product.Stock = productInsert.Stock;
                product.Price = productInsert.Price;
                product.Discount = productInsert.Discount;
                product.CategoryId = productInsert.CategoryId;
                product.IsActive = true;
                return await _productRepository.Insert(product);
            }
            return false;
        }
    }
}

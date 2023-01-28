using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductWithDTOController : CustomBaseController
    {
        private readonly IProductServiceWithDTO _productServiceWithDTO;

        public ProductWithDTOController(IProductServiceWithDTO productServiceWithDTO)
        {
            _productServiceWithDTO = productServiceWithDTO;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            return CreateActionResult(await _productServiceWithDTO.GetProductsWithCateogry());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            return CreateActionResult(await _productServiceWithDTO.GetAllAsync());
        }

        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateActionResult(await _productServiceWithDTO.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductCreateDTO productCreateDTO)
        {
            return CreateActionResult(await _productServiceWithDTO.AddAsync(productCreateDTO));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDTO productDTO)
        {
            return CreateActionResult(await _productServiceWithDTO.UpdateAsync(productDTO));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            return CreateActionResult(await _productServiceWithDTO.RemoveAsync(id));
        }
    }
}

using NLayer.Core.DTOs;
using NLayer.Core.Models;

namespace NLayer.Core.Services
{
    public interface IProductServiceWithDTO : IServiceWithDTO<Product, ProductDTO>
    {
        Task<CustomResponseDTO<List<ProductWithCategoryDTO>>> GetProductsWithCateogry();

        Task<CustomResponseDTO<NoContentDTO>> UpdateAsync(ProductUpdateDTO dto);

        Task<CustomResponseDTO<ProductDTO>> AddAsync(ProductCreateDTO dto);
    }
}

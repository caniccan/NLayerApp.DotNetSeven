using AutoMapper;
using Microsoft.AspNetCore.Http;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class ProductServiceWithDTO : ServiceWithDTO<Product, ProductDTO>, IProductServiceWithDTO
    {
        private readonly IProductRepository _productRepository;

        public ProductServiceWithDTO(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IMapper mapper, IProductRepository productRepository) : base(repository, unitOfWork, mapper)
        {
            _productRepository = productRepository;
        }

        public async Task<CustomResponseDTO<ProductDTO>> AddAsync(ProductCreateDTO dto)
        {
            var newEntity = _mapper.Map<Product>(dto);
            await _productRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();
            var newDTO = _mapper.Map<ProductDTO>(newEntity);
            return CustomResponseDTO<ProductDTO>.Success(StatusCodes.Status200OK, newDTO);
        }

        public async Task<CustomResponseDTO<List<ProductWithCategoryDTO>>> GetProductsWithCateogry()
        {
            var product = await _productRepository.GetProductsWithCateogry();
            var productsDTO = _mapper.Map<List<ProductWithCategoryDTO>>(product);
            return CustomResponseDTO<List<ProductWithCategoryDTO>>.Success(200, productsDTO);
        }

        public async Task<CustomResponseDTO<NoContentDTO>> UpdateAsync(ProductUpdateDTO dto)
        {
            var entity = _mapper.Map<Product>(dto);
            _productRepository.Update(entity);
            await _unitOfWork.CommitAsync();
            return CustomResponseDTO<NoContentDTO>.Success(StatusCodes.Status204NoContent);
        }
    }
}

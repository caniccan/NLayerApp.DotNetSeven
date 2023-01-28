using NLayer.Core.DTOs;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Services
{
    public interface IServiceWithDTO<Entity,DTO> where Entity : BaseEntity where DTO: class
    {
        Task<CustomResponseDTO<DTO>> GetByIdAsync(int id);
        Task<CustomResponseDTO<IEnumerable<DTO>>> GetAllAsync();
        Task<CustomResponseDTO<IEnumerable<DTO>>> Where(Expression<Func<Entity, bool>> expression);
        Task<CustomResponseDTO<bool>> AnyAsync(Expression<Func<Entity, bool>> expression);
        Task<CustomResponseDTO<DTO>> AddAsync(DTO dto);
        Task<CustomResponseDTO<IEnumerable<DTO>>> AddRangeAsync(IEnumerable<DTO> dtos);
        Task<CustomResponseDTO<NoContentDTO>> UpdateAsync(DTO dto);
        Task<CustomResponseDTO<NoContentDTO>> RemoveAsync(int id);
        Task<CustomResponseDTO<NoContentDTO>> RemoveRangeAsync(IEnumerable<int> ids);
    }
}

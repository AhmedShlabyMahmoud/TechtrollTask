using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechtrollTask.Application.DTOs;

namespace TechtrollTask.Application.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(int id);
        Task<int> CreateAsync(ProductDto product);
        Task UpdateAsync(int id, ProductDto product);
        Task DeleteAsync(int id);
    }

}

using ProductManagement.Application.DTOs;

namespace ProductManagement.Application.Interfaces;

public interface IProductService
{
    Task<PagedResult<ProductDto>> GetAllAsync(int page, int pageSize);
    Task<ProductDto?> GetByIdAsync(int id);
    Task CreateAsync(ProductDto productDto);
    Task UpdateAsync(int id, ProductDto productDto);
    Task DeleteAsync(int id);
}

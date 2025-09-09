using ProductManagement.Application.DTOs;
using ProductManagement.Application.Interfaces;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Interfaces;

namespace ProductManagement.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<PagedResult<ProductDto>> GetAllAsync(int page, int pageSize)
    {
        var products = await _repository.GetAllAsync(page, pageSize);
        var total = await _repository.GetTotalCountAsync();

        return new PagedResult<ProductDto>
        {
            Items = products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                CreatedAt = p.CreatedAt
            }),
            TotalCount = total,
            Page = page,
            PageSize = pageSize
        };
    }

    public async Task<ProductDto?> GetByIdAsync(int id)
    {
        var product = await _repository.GetByIdAsync(id);
        if (product == null) return null;

        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            CreatedAt = product.CreatedAt
        };
    }

    public async Task CreateAsync(ProductDto productDto)
    {
        if (string.IsNullOrEmpty(productDto.Name))
            throw new ArgumentException("Name is required");
        if (productDto.Price <= 0)
            throw new ArgumentException("Price must be greater than 0");

        var product = new Product
        {
            Name = productDto.Name,
            Description = productDto.Description,
            Price = productDto.Price,
            CreatedAt = DateTime.UtcNow
        };

        await _repository.AddAsync(product);
    }

    public async Task UpdateAsync(int id, ProductDto productDto)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null) throw new KeyNotFoundException("Product not found");

        if (string.IsNullOrEmpty(productDto.Name))
            throw new ArgumentException("Name is required");
        if (productDto.Price <= 0)
            throw new ArgumentException("Price must be greater than 0");

        existing.Name = productDto.Name;
        existing.Description = productDto.Description;
        existing.Price = productDto.Price;

        await _repository.UpdateAsync(existing);
    }

    public async Task DeleteAsync(int id)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null) throw new KeyNotFoundException("Product not found");

        await _repository.DeleteAsync(id);
    }
}
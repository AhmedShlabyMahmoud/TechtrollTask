using Microsoft.EntityFrameworkCore;
using TechtrollTask.Application.DTOs;
using TechtrollTask.Application.Interfaces;
using TechtrollTask.Domain.Entities;
using TechtrollTask.Infrastructure.Persistence;

public class ProductService : IProductService
{
    private readonly FurnitureDbContext _context;

    public ProductService(FurnitureDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProductDto>> GetAllAsync()
    {
        var products = await _context.Products
            .Include(p => p.Components)
                .ThenInclude(c => c.Subcomponents)
            .ToListAsync();

        return products.Select(p => MapToDto(p)).ToList();
    }

    public async Task<ProductDto?> GetByIdAsync(int id)
    {
        var product = await _context.Products
            .Include(p => p.Components)
                .ThenInclude(c => c.Subcomponents)
            .FirstOrDefaultAsync(p => p.Id == id);

        return product == null ? null : MapToDto(product);
    }

    public async Task<int> CreateAsync(ProductDto dto)
    {
        var product = MapToEntity(dto);
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product.Id;
    }

    public async Task UpdateAsync(int id, ProductDto dto)
    {
        var existing = await _context.Products
            .Include(p => p.Components)
                .ThenInclude(c => c.Subcomponents)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (existing == null) throw new Exception("Not found");

        existing.Name = dto.Name;
        existing.Price = dto.Price;


        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }

    private ProductDto MapToDto(Product product) => new ProductDto
    {
        Name = product.Name,
        Price = product.Price,
        Components = product.Components?.Select(c => new ComponentDto
        {
            Name = c.Name,
            Quantity = c.Quantity,
            Subcomponents = c.Subcomponents?.Select(s => new SubcomponentDto
            {
                Name = s.Name,
                Material = s.Material,
                CustomNotes = s.CustomNotes,
                Count = s.Count,
                DetailLength = s.DetailLength,
                DetailWidth = s.DetailWidth,
                DetailThickness = s.DetailThickness,
                CuttingLength = s.CuttingLength,
                CuttingWidth = s.CuttingWidth,
                CuttingThickness = s.CuttingThickness,
                FinalLength = s.FinalLength,
                FinalWidth = s.FinalWidth,
                FinalThickness = s.FinalThickness,
                VeneerInner = s.VeneerInner,
                VeneerOuter = s.VeneerOuter
            }).ToList()
        }).ToList()
    };

    private Product MapToEntity(ProductDto dto) => new Product
    {
        Name = dto.Name,
        Price = dto.Price,
        Components = dto.Components?.Select(c => new Component
        {
            Name = c.Name,
            Quantity = c.Quantity,
            Subcomponents = c.Subcomponents?.Select(s => new Subcomponent
            {
                Name = s.Name,
                Material = s.Material,
                CustomNotes = s.CustomNotes,
                Count = s.Count,
                DetailLength = s.DetailLength,
                DetailWidth = s.DetailWidth,
                DetailThickness = s.DetailThickness,
                CuttingLength = s.CuttingLength,
                CuttingWidth = s.CuttingWidth,
                CuttingThickness = s.CuttingThickness,
                FinalLength = s.FinalLength,
                FinalWidth = s.FinalWidth,
                FinalThickness = s.FinalThickness,
                VeneerInner = s.VeneerInner,
                VeneerOuter = s.VeneerOuter
            }).ToList()
        }).ToList()
    };
}

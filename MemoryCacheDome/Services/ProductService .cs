using MemoryCacheDemo.Entities;
using MemoryCacheDemo.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace MemoryCacheDemo.Services;

public class ProductService : IProductService
{
    private readonly DataContext _context;
    private readonly IMemoryCache _memoryCache;

    public ProductService(DataContext context, IMemoryCache memoryCache)
    {
        _context = context;
        _memoryCache = memoryCache;
    }

    public async Task<List<Product>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Products
            .OrderBy(x => x.Name)
            .ToListAsync(cancellationToken);
    }
}
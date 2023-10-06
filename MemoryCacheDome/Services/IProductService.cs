using MemoryCacheDemo.Entities;

namespace MemoryCacheDemo.Services;

public interface IProductService
{
    Task<List<Product>> GetAll(CancellationToken cancellationToken);
}
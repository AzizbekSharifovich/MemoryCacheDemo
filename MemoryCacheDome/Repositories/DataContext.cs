using MemoryCacheDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace MemoryCacheDemo.Repositories;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Product> Products { get; set; }
}

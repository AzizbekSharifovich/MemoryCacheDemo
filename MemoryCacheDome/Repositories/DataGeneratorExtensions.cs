using Bogus;
using MemoryCacheDemo.Entities;

namespace MemoryCacheDemo.Repositories;

public static class DataGeneratorExtensions
{
    public static async Task GenerateProduct(this DataContext context, int count)
    {
        var productFaker = new Faker<Product>()
            .RuleFor(prop => prop.Name, setter => setter.Commerce.ProductName())
            .RuleFor(prop => prop.Description, setter => setter.Commerce.ProductDescription())
            .RuleFor(prop => prop.Price, setter => Convert.ToDecimal(setter.Commerce.Price()));

        var products = productFaker.Generate(count);
        await context.Products.AddRangeAsync(products);
        await context.SaveChangesAsync();
    }
}

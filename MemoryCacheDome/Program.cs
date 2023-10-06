using MemoryCacheDemo.Repositories;
using MemoryCacheDemo.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("MemoryDb");

builder.Services.AddDbContext<DataContext>(options =>
options.UseNpgsql("MemoryDb"));

builder.Services.AddMemoryCache();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.Decorate<IProductService, CachedProductService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();

if (await context.Database.EnsureCreatedAsync())
    await context.GenerateProduct(1000);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.MapControllers();
app.Run();
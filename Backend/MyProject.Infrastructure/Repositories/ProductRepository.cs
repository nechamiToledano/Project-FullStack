using Microsoft.EntityFrameworkCore;
using MyProject.Domain.Entities;
using MyProject.Domain.Repositories;
using MyProject.Infrastructure.Data;

namespace MyProject.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _ctx;
    public ProductRepository(AppDbContext ctx) => _ctx = ctx;

    public async Task AddAsync(Product product)
    {
        _ctx.Products.Add(product);
        await _ctx.SaveChangesAsync();
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
        => await _ctx.Products.AsNoTracking().ToListAsync();

    public async Task<Product?> GetByIdAsync(Guid id)
        => await _ctx.Products.FindAsync(id);
}
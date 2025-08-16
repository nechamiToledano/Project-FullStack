using MyProject.Domain.Entities;
using MyProject.Domain.Repositories;

namespace MyProject.Application.Services;

public class ProductService
{
    private readonly IProductRepository _repo;
    public ProductService(IProductRepository repo) => _repo = repo;

    public async Task<IEnumerable<Product>> GetAllAsync()
        => await _repo.GetAllAsync();

    public async Task AddProductAsync(string name, decimal price)
    {
        var p = new Product(name, price);
        await _repo.AddAsync(p);
    }
}
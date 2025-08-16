using Microsoft.AspNetCore.Mvc;
using MyProject.Application.Services;

namespace MyProject.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ProductService _service;
    public ProductController(ProductService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _service.GetAllAsync());

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductDto dto)
    {
        await _service.AddProductAsync(dto.Name, dto.Price);
        return CreatedAtAction(nameof(GetAll), null);
    }

}
public record CreateProductDto(string Name, decimal Price);
using Microsoft.AspNetCore.Mvc;
using MyProject.Application.Services;
using MyProject.Api.DTOs;

namespace MyProject.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
    {
        var token = await _authService.RegisterAsync(request.Email, request.Password);
        return Ok(new { Token = token });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
    {
        var token = await _authService.LoginAsync(request.Email, request.Password);
        return Ok(new { Token = token });
    }
}

